using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStore.Controllers;
using OnlineBookStore.Models;
using OnlineBookStore.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace OnlineBookStoreTest
{
    [TestClass]
    public class UserControllerTest
    {
        List<User> users;
        [TestInitialize]
        public void Setup()
        {
            users = new List<User>
            {
                new User
                {
                    UserId=1,
                    Name="User1",
                    Address="Address1",
                    Email="user1@gmail.com"
                },
                new User
                {
                    UserId=2,
                    Name="User2",
                    Address="Address2",
                    Email="user2@gmail.com"
                },
                new User
                {
                    UserId=3,
                    Name="User3",
                    Address="Address3",
                    Email="user3@gmail.com"
                }
            };
        }

        [TestMethod]
        public void GetUserId_returnsOk()
        {
            string uname = "User1";
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetUser(uname)).Returns(( users.Where(x => x.Name == uname).FirstOrDefault()).UserId);
            UserController controller = new UserController(mock.Object);
            var res = controller.GetUserId(uname);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void GetUserId_returnsBadRequest()
        {
            string uname = "user4";
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetUser(uname)).Returns(Convert.ToInt32(users.Where(x => x.Name == uname).FirstOrDefault()));
            UserController controller = new UserController(mock.Object);
            var res = controller.GetUserId(uname);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void PostUser_returnOk()
        {
            User user = new User
            {
                Name = "User4",
                Address = "Address4",
                Email = "user4@gmail.com"
            };
            var mock = new Mock<IUserRepository>();
            UserController controller = new UserController(mock.Object);
            var res = controller.PostUser(user);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void PostUser_returnBadRequest()
        {
            User user = new User
            {
                Name = "User3",
                Address = "Address3",
                Email = "user3@gmail.com"
            };
            var mock = new Mock<IUserRepository>();
            UserController controller = new UserController(mock.Object);
            var res = controller.PostUser(user);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
