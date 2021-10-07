using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Models;

namespace OnlineBookStore.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBookByID(int id);
        public string PostBook(Book book,int userId);
        public string UpdateRating(Book book);
    }
}
