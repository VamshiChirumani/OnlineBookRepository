using Microsoft.AspNetCore.Mvc;
using System;
using OnlineBookStore.Repositories;
using OnlineBookStore.CustomExceptions;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OrdersController));
        public static int userId=0;
        public static void method1(int id)
        {
            userId = id;
        }
        IOrderRepository orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetOrdersOfUsers()
        {
            _log4net.Info("OrdersController-GetOrdersOfUsers-Called");
            try
            {
                _log4net.Info("OrdersController-GetOrdersOfUsers-OrdersOfUserShown");
                if (userId == 0)
                {
                    throw new UserNotSignedInException();
                }
                return Ok(orderRepository.GetOrdersOfUser(userId));
            }
            catch(Exception e)
            {
                _log4net.Error("OrdersController-GetOrdersOfUsers-" + e.Message);
                return BadRequest(e.Message);
            }
            
        }
        [HttpPost]
        public IActionResult PostOrdersFromCart()
        {
            _log4net.Info("OrdersController-PostOrdersFromCart-Called");
            try
            {
                _log4net.Info("OrdersController-PostOrdersFromCart-OrderRecievedFromCart");
                if (userId == 0)
                {
                    throw new UserNotSignedInException();
                }
                return Ok(orderRepository.PostOrdersFromCart(userId));
            }
            catch (Exception e)
            {
                _log4net.Info("OrdersController-PostOrdersFromCart-" + e.Message);
                return BadRequest(e.Message);
            }
            
        }
        [HttpPost("/api/PostBookOrderFromSell")]
        public IActionResult PostBookOrderFromSell(int bookId )
        {
            _log4net.Info("OrdersController-PostBookOrderFromSell-Called");
            try
            {
                _log4net.Info("OrdersController-PostBookOrderFromSell-BookSold");
                if (userId == 0)
                {
                    throw new UserNotSignedInException();
                }
                return Ok(orderRepository.PostBookOrderFromSell(userId, bookId));
            }
            catch (Exception e)
            {
                _log4net.Info("OrdersController-PostBookOrderFromSell-" + e.Message);
                return BadRequest(e.Message);
            }
            
        }
        [HttpPost("/api/PostBookOrderFromBookList")]
        public IActionResult PostBookOrderFromBookList( int BookId)
        {
            _log4net.Info("OrdersController-PostBookOrderFromBookList-Called");
            try
            {
                _log4net.Info("OrdersController-PostBookOrderFromBookList-PostedBookFromList");
                if (userId == 0)
                {
                    throw new UserNotSignedInException();
                }
                return Ok(orderRepository.PostBookOrderFromBooksList(userId, BookId));
            }
            catch (Exception e)
            {
                _log4net.Info("OrdersController-PostBookOrderFromBookList-"+e.Message);
                return BadRequest(e.Message);
            }
            
        }

    }
}
