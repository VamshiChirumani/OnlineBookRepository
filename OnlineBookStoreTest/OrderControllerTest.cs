using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStore.Controllers;
using OnlineBookStore.Models;
using OnlineBookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStoreTest
{
    [TestClass]
    public class OrderControllerTest
    {
        List<Order> Orders;
        [TestInitialize]
        public void Setup()
        {
            Orders = new List<Order>
            {
                new Order
                {
                    OrderId=1,
                    UserId=1,
                    Amount=100,
                    Category="Buy"
                },
                new Order
                {
                    OrderId=2,
                    UserId=1,
                    Amount=200,
                    Category="Sell"
                },
                new Order
                {
                    OrderId=3,
                    UserId=2,
                    Amount=300,
                    Category="Buy"
                },
                new Order
                {
                    OrderId=4,
                    UserId=2,
                    Amount=400,
                    Category="Sell"
                }
            };
        }
        [TestMethod]
        public void GetOrders_ReturnsOk()
        {
            int uid = 1;
            var mock = new Mock<IOrderRepository>();
            mock.Setup(x => x.GetOrdersOfUser(uid)).Returns(Orders.Where(x => x.UserId == uid).ToList());
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.GetOrdersOfUsers();
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void GetOrders_ReturnsBadRequest()
        {
            int uid = 0;
            var mock = new Mock<IOrderRepository>();
            mock.Setup(x => x.GetOrdersOfUser(uid)).Returns(Orders.Where(x => x.UserId == uid).ToList());
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.GetOrdersOfUsers();
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void PostBookOrderFromBookList_ReturnsOk()
        {
            int uid = 1;
            int bookId = 1;
            var mock = new Mock<IOrderRepository>();
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.PostBookOrderFromBookList(bookId);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void PostBookOrderFromBookList_ReturnsBadRequest()
        {
            int uid = 0;
            int bookId = 1;
            var mock = new Mock<IOrderRepository>();
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.PostBookOrderFromBookList(bookId);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void PostBookOrderSell_ReturnsOk()
        {
            int uid = 1;
            int bookId = 1;
            var mock = new Mock<IOrderRepository>();
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.PostBookOrderFromSell(bookId);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void PostBookOrderSell_ReturnsBadRequest()
        {
            int uid = 0;
            int bookId = 1;
            var mock = new Mock<IOrderRepository>();
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.PostBookOrderFromSell(bookId);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void PostOrdersFromCart_returnsOk()
        {
            int uid = 1;
            var mock = new Mock<IOrderRepository>();
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.PostOrdersFromCart();
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void PostOrdersFromCart_returnsBadRequest()
        {
            int uid = 0;
            var mock = new Mock<IOrderRepository>();
            OrdersController controller = new OrdersController(mock.Object);
            OrdersController.userId = uid;
            var res = controller.PostOrdersFromCart();
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
