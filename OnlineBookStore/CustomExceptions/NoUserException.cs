using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class NoUserException:Exception
    {
        public NoUserException(string userName):
            base("No user with username " + userName)
        {

        }
    }
}
