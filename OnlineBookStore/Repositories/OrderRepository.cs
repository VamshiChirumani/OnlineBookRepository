using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        CoreDbContext _context;
        public OrderRepository(CoreDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Order> GetOrdersOfUser(int userId)
        {
            return _context.Orders.Where(x => x.UserId == userId).ToList();
        }

        public string PostBookOrderFromBooksList(int userId,int BookId)
        {
            Book book = _context.Books.Find(BookId);
            Order order = new Order
            {
                OrderId = 0,
                UserId = userId,
                Amount = book.Cost,
                Category = "Buy"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return "added successfully";
        }

        public string PostBookOrderFromSell(int userId, int BookId)
        {
            Book book = _context.Books.Find(BookId);
            Order order = new Order
            {
                OrderId = 0,
                UserId = userId,
                Amount = book.Cost,
                Category = "Sell"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return "added successfully";
        }

        public string PostOrdersFromCart(int userID)
        {
            List<CartItem> cartItems = _context.CartItems.Where(x => x.userId == userID).ToList();
            int amount = 0;
            foreach (var item in cartItems)
            {
                Book book = _context.Books.Find(item.BookId);
                amount += book.Cost;
            }
            Order order = new Order
            {
                OrderId = 0,
                Category = "Buy",
                UserId = userID,
                Amount = amount
            };
            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(
                _context.CartItems.Where(x=>x.userId==userID).ToList()
                );
            _context.SaveChanges();
            return "added successfully";

        }
    }
}
