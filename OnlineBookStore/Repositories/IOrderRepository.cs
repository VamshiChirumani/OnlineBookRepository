using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrdersOfUser(int userId);
        public string PostOrdersFromCart(int userID);
        public string PostBookOrderFromBooksList(int userId,int BookId);
        public string PostBookOrderFromSell(int userId, int BookId);
    }
}
