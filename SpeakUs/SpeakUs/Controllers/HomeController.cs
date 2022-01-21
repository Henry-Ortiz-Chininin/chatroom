using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeakUs.Models;

namespace SpeakUs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            Models.DTOSignUp signUp = new Models.DTOSignUp();
            signUp.Message = "Fill the inputs";

            ViewBag.Message = "SignUp.";

            return View(signUp);
        }

        [HttpPost]
        public ActionResult SignUp(DTOSignUp signUp)
        {
            DataRepository.Interfaces.iUserRepository iUserRepository = new DataRepository.Repositories.UserRepository();

            if (string.IsNullOrWhiteSpace(signUp.UserName) ||
                string.IsNullOrWhiteSpace(signUp.Password) ||
                string.IsNullOrWhiteSpace(signUp.SpeakerName))
            {
                signUp.Message = "All inputs must filled";
                return View(signUp);
            }
            if (iUserRepository.existUser(signUp.UserName))
            {
                signUp.Message = $"User {signUp.UserName} already exist";
                return View(signUp);
            }

            try
            {
                DataEntity.User user = new DataEntity.User();
                user.Id = user.GetID();
                user.UserName = signUp.UserName;
                user.Password = signUp.Password;
                iUserRepository.Add(user);

                DataEntity.Speaker speaker = new DataEntity.Speaker();
                speaker.UserId = user.Id;
                speaker.Name = signUp.SpeakerName;
                speaker.Status = Crossover.Status.SpeakerStatus.ACTIVO;
                DataRepository.Interfaces.iSpeakerRepository iSpeakerRepository = new DataRepository.Repositories.SpeakerRepository();
                iSpeakerRepository.Add(speaker);

                signUp.Message = $"{signUp.SpeakerName} go to Login page";
            } catch (Exception ex)
            {
                signUp.Message = $"Something went wrong. Check the information and try again.";
            }


            ViewBag.Message = "SignUp.";

            return View(signUp);
        }

        public ActionResult Login()
        {
            DTOLogin login = new DTOLogin();

            ViewBag.Message = "Authenticate User";
            return View(login);
        }

        [HttpPost] 
        public ActionResult Login(DTOLogin login)
        {
            if(string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
            {
                login.Message = "All inputs must filled";
                return View(login);
            }

                    

            DataRepository.Interfaces.iUserRepository iUserRepository = new DataRepository.Repositories.UserRepository();
            DataEntity.User user = iUserRepository.Authenticate(login.UserName, login.Password);
            if(user!=null &&  !String.IsNullOrEmpty(user.Id))
            {
                return RedirectToAction("Index", "Chat",new { @SessionId = user.Id });
            }


            login.Message = "User not found";

            ViewBag.Message = "Authenticate User";
            return View(login);
        }

    }
}