using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class UserNotSignedInException:Exception
    {
        public UserNotSignedInException():
            base("User not signed in")
        {

        }
    }
}
