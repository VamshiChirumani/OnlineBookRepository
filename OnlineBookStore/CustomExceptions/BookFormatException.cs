using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class BookFormatException:Exception
    {
        public BookFormatException()
        {

        }
        public BookFormatException(Book book):
            base("Check the fromat of the book ")
        {
        }
    }
}
