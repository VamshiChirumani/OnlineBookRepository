using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.CustomExceptions;
using OnlineBookStore.Repositories;
using System;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        public static int userId=0;
        public static void method1(int id)
        {
            userId = id;
        }
        ICartRepository cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        [HttpGet("/api/GetCartItems")]
        public IActionResult GetCartItems()
        {
            _log4net.Info("CartController-GetCartItems-Called");
            try
            {
                _log4net.Info("CartController-GetCartItems-CartItemsReturned");
                if (userId == 0)
                {
                    throw new UserNotSignedInException();
                }
                return Ok(cartRepository.GetItems(userId));
            }
            
            catch(Exception e)
            {
                _log4net.Error("CartController-GetCartItems" + e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpPost("/api/PostCartItems")]
        public IActionResult PostCartItems([FromBody]int BookId)
        {
            _log4net.Info("CartController-PostCartItems-Called");
            try
            {
                _log4net.Info("CartController-PostCartItems-ItemAddedToCart");
                if (userId == 0)
                {
                    throw new UserNotSignedInException();
                }
                return Ok(cartRepository.AddItemToCart(BookId, userId));
            }
            catch(Exception e)
            {
                _log4net.Error("CartController-PostCartItems" + e.Message);
                return BadRequest(e.Message);
            }
        }
        
    }
}
