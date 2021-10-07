using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomExceptions
{
    public class RatingException:Exception
    {
        public RatingException(int rating):
            base(string.Format("Rating should be in range of 0 to 5 but give is {0}", rating))
        {

        }
    }
}
