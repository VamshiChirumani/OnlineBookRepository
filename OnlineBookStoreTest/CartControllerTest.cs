using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStore.Controllers;
using OnlineBookStore.Models;
using OnlineBookStore.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineBookStoreTest
{
    [TestClass]
    public class CartControllerTest
    {
        List<CartItem> items;
        [TestInitialize]
        public void SetUp()
        {
            items = new List<CartItem>
            {
                new CartItem
                {
                    ItemId=1,
                    BookId=1,
                    userId=1
                },
                new CartItem
                {
                    ItemId=2,
                    BookId=2,
                    userId=1
                },
                new CartItem
                {
                    ItemId=3,
                    BookId=1,
                    userId=2
                },
                new CartItem
                {
                    ItemId=4,
                    BookId=2,
                    userId=2
                },
            };
        }

        [TestMethod]
        public void GetCartItems_ReturnsOk()
        {
            int uid = 1;
            var mock = new Mock<ICartRepository>();
            mock.Setup(x => x.GetItems(uid)).Returns(items.Where(x => x.userId == uid).ToList());
            CartController controller = new CartController(mock.Object);
            CartController.userId = 1;
            var res = controller.GetCartItems();
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GetCartItems_ReturnsBadRequest()
        {
            int uid = 0;
            var mock = new Mock<ICartRepository>();
            mock.Setup(x => x.GetItems(uid)).Returns(items.Where(x => x.userId == uid).ToList());
            CartController controller = new CartController(mock.Object);
            CartController.userId = 0;
            var res = controller.GetCartItems();
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void PostCartItems_ReturnsOk()
        {
            int uid = 1;
            var mock = new Mock<ICartRepository>();
            CartItem CI = new CartItem
            {
                ItemId = 1,
                BookId = 2,
                userId = uid
            };
            CartController controller = new CartController(mock.Object);
            CartController.userId = uid;
            var res = controller.PostCartItems(CI.BookId);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void PostCartItems_ReturnsbadRequest()
        {
            int uid = 0;
            var mock = new Mock<ICartRepository>();
            CartItem CI = new CartItem
            {
                ItemId = 1,
                BookId = 2,
                userId = uid
            };
            CartController controller = new CartController(mock.Object);
            CartController.userId = uid;
            var res = controller.PostCartItems(CI.BookId);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
