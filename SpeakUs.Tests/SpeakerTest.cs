using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataEntity;
using DataRepository.Repositories;
using Crossover.Status;
using System.Collections.Generic;

namespace SpeakUs.Tests
{
    [TestClass]
    public class SpeakerTest
    {
        [TestMethod]
        public void Validate_SpeakerRepository_Test()
        {
            User user = new User();
            user.Id = "3A7A5AC5-780E-4593-988E-A1689358D704";
            user.UserName = "Henry";
            user.Password = "20220115210800";

            UserRepository repository = new UserRepository();

            //ADD USER
            if (!repository.existUser(user.UserName))
            {
                string result = repository.Add(user);
                Assert.AreEqual(user.Id, result);
            }

            SpeakerRepository speakerRepository = new SpeakerRepository();

            speakerRepository.Remove(user.Id);

            Speaker speaker = new Speaker();
            speaker.UserId = user.Id;
            speaker.Name = "Henry Ortiz";
            speaker.Status = SpeakerStatus.ACTIVO;

            
            speakerRepository.Add(speaker);

            Speaker newSpeaker= speakerRepository.GetSpeaker(user.Id);
            Assert.AreEqual(speaker.Name, newSpeaker.Name);

            speaker.Name = "Henry Ortiz Chininin";

            speakerRepository.Update(speaker);

            newSpeaker = speakerRepository.GetSpeaker(user.Id);
            Assert.AreEqual(speaker.Name, newSpeaker.Name);

            speakerRepository.Remove(speaker.UserId);

        }
    }
}
