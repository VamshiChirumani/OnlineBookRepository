using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Repositories
{

    public class UserRepository:IUserRepository
    {
        CoreDbContext _context;
        public UserRepository(CoreDbContext context)
        {
            _context = context;
        }

        public int GetUser(string username)
        {
            User u = _context.Users.Where(x => x.Name == username).FirstOrDefault();
            return u.UserId;
        }


        public int PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }
    }
}
