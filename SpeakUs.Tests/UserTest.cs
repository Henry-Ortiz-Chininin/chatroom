using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataEntity;
using DataRepository.Repositories;
using Crossover;
using System.Collections.Generic;

namespace SpeakUs.Tests
{
    [TestClass]
    public class UserTest
    {            
        

        [TestMethod]
        public void Validate_UserRepository_Test()
        {
            User user = new User();
            user.Id = "3A7A5AC5-780E-4593-988E-A1689358D704";
            user.UserName = "Henry";
            user.Password = "20220115210800";

            UserRepository repository = new UserRepository();

            //ADD USER
            if(!repository.existUser(user.UserName))
            {
                string result = repository.Add(user);
                Assert.AreEqual(user.Id, result);
            }

            //USER EXISTS
            Assert.IsTrue(repository.existUser(user.UserName));

            //MODIFY USER
            user.UserName = "UserTest";
            Assert.AreEqual(user.Id,repository.Update(user));

            //GET USER
            User newUser = repository.GetUser(user.Id);
            Assert.AreEqual(user.UserName, newUser.UserName);

            //AUTHENTICATE USER
            User validUser = repository.Authenticate(newUser.UserName, newUser.Password);
            Assert.AreEqual(newUser.Id, validUser.Id);

            List<User> users = repository.GetUsers();
            Assert.AreNotEqual(users.Count, 0);

            //REMOVE USER
            Assert.IsTrue(repository.Remove(newUser.Id));

            
        }


    }
}
