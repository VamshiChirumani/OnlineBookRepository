using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class BookNotFoundException:Exception
    {
        public BookNotFoundException() { }
        public BookNotFoundException(int id) :
            base(String.Format("Book with id {0} is not present", id))
        {
        }
    }
}
