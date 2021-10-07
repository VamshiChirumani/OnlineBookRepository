using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using OnlineBookStore.Repositories;
using OnlineBookStore.Models;
using OnlineBookStore.CustomExceptions;

namespace OnlineBookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public static int userId=0;
        public static void method1(int id)
        {
            userId = id;
        }
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BooksController));
        IBookRepository BookRepos;
        public BooksController(IBookRepository bookRepository)
        {
            this.BookRepos = bookRepository;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            _log4net.Info("BooksController-GetBooks Called"); 
            try
            {
                _log4net.Info("BooksController-GetBooks-BooksReturned");
                var books = BookRepos.GetAllBooks().ToList();
                if (books.Count==0)
                {
                    throw new NoBooksFoundException();
                }

                return Ok(BookRepos.GetAllBooks().ToList());
            }
            catch(Exception e)
            {
                _log4net.Error("BooksController-GetBooks-" + e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpGet("/api/Book/{id}")]
        public IActionResult GetBookById(int id)
        {
            _log4net.Info("BooksController-GetBookById called");
            try
            {
                _log4net.Info("BooksController-GetBookById-BookReturned");
                Book book = BookRepos.GetBookByID(id);
                if (book == null)
                {
                    throw new BookNotFoundException(id);
                }
                return Ok(book);
            }
            catch (Exception e)
            {
                _log4net.Error("BooksController-GetBookById-" + e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult PostBook([FromBody]Book book)
        {
            _log4net.Info("BooksController-PostBook-called");
            try
            {
                _log4net.Info("BooksController-PostBook-BookPosted");
                if((book.BookName.Equals(""))|(book.Cost<1)| (book.Rating < 0) | (book.Rating > 5))
                {
                    throw new BookFormatException(book);
                }
                return Ok(BookRepos.PostBook(book, userId));
            }
            catch(Exception e)
            {
                _log4net.Error("BooksController-PostBook-" + e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateBook([FromBody] Book book)
        {
            _log4net.Info("BooksController-UpdateBook-called");
            try
            {
                _log4net.Info("BooksController-UpdateBook-BookUpdated");
                if ((book.Rating < 0) | (book.Rating >5))
                {
                    throw new RatingException(book.Rating);
                }
                return Ok(BookRepos.UpdateRating(book));
            }
            catch(Exception e)
            {
                _log4net.Error("BooksController-UpdateBook-" + e.Message);
                return BadRequest(e.Message);
            }
            
        }

    }
}
