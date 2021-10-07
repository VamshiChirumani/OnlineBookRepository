
using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Repositories;
using OnlineBookStore.Models;
using System;
using OnlineBookStore.CustomExceptions;

namespace OnlineBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        int USERID=0;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserController));
        IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetUserId(string userName)
        {
            _log4net.Info("UserController-GetUserId-Called");
            try
            {
                _log4net.Info("UserController-GetUserId-UserNameRecieved");
                USERID = userRepository.GetUser(userName);
                if (USERID == 0)
                {
                    throw new NoUserException(userName);
                }
                CartController.method1(USERID);
                BooksController.method1(USERID);
                OrdersController.method1(USERID);
                return Ok(USERID);
            }
            catch(Exception e)
            {
                _log4net.Error("UserController-GetUser" + e.Message);
                return BadRequest(e.Message);
            }
            
        } 
        [HttpPost]
        public IActionResult PostUser([FromBody]User user)
        {
            _log4net.Info("UserController-PostUser-Called");
            try
            {
                _log4net.Info("UserController-PostUser-NewUserCreated");
                string userName = user.Name;
                int uexist = userRepository.GetUser(userName);
                if( uexist != 0)
                {
                    throw new UserExistsException(user.Name);
                }
                USERID =userRepository.PostUser(user);
                CartController.method1(USERID);
                BooksController.method1(USERID);
                OrdersController.method1(USERID);
                return Ok(USERID);
            }
            catch (Exception e)
            {
                _log4net.Error("UserController-PostUser"+e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
