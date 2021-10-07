using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.Models;

namespace OnlineBookStore.Repositories
{
    public interface IUserRepository
    {
        public  int GetUser(string username);
        public int PostUser(User user); 
    }
}
