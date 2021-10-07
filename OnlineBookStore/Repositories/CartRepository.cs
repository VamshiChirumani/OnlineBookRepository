using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Repositories
{
    public class CartRepository : ICartRepository
    {
        CoreDbContext _context;
        public CartRepository(CoreDbContext context)
        {
            this._context = context;
        }

        public string AddItemToCart(int BookId, int Userid)
        {

            try
            {
                CartItem c = new CartItem
                {
                    ItemId = 0,
                    userId = Userid,
                    BookId = BookId
                };
                _context.CartItems.Add(c);
                _context.SaveChanges();
                return "Added successfully";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }

        public IEnumerable<CartItem> GetItems(int UserId)
        {
            return _context.CartItems.Where(x => x.userId == UserId).ToList();
        }
    }
}
