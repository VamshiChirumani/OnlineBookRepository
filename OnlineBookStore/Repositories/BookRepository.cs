using Newtonsoft.Json;
using OnlineBookStore.CustomExceptions;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        CoreDbContext _context;
        public BookRepository(CoreDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookByID(int id)
        {
            Book book = _context.Books.Find(id);
            if (book.Equals(null))
            {
                return null;
            }

            return book;
        }

        public string PostBook(Book book,int userId)
        {
            if (book.BookName.Equals(""))
            {
                throw new BookFormatException(book);
            }
            _context.Books.Add(book);
            Order order = new Order
            {
                OrderId = 0,
                UserId = userId,
                Amount = book.Cost,
                Category = "Sell"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return "Added successfuly";
        }

        public string UpdateRating(Book book)
        {
            Book b = _context.Books.Find(book.BookId);
            b.Rating = book.Rating;
            _context.Books.Update(b);
            _context.SaveChanges();
            return "updated successfully";
        }
    }
}
