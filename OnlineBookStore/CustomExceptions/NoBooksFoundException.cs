using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class NoBooksFoundException:Exception
    {
        public NoBooksFoundException():base("There are no books available")
        {

        }
    }
}
