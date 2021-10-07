using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Repositories
{
    public interface ICartRepository
    {
        public IEnumerable<CartItem> GetItems(int userId);
        public string AddItemToCart(int BookId, int Userid);
    }
}
