using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class UserExistsException:Exception

    {
        public UserExistsException(string uname):
            base("UserName "+ uname +" alrady exists")
        {

        }
    }
}
