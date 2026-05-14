using CetBookStore.Data;
using CetBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CetBookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Book)
                .Where(c => c.UserId == "Guest")
                .ToListAsync();

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int bookId)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.UserId == "Guest" && c.BookId == bookId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = "Guest",
                    BookId = bookId,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Book)
                .Where(c => c.UserId == "Guest")
                .ToListAsync();

            if (!cartItems.Any()) return RedirectToAction(nameof(Index));

            var order = new Order
            {
                UserId = "Guest",
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(c => c.Quantity * (c.Book.Price)),
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in cartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    Price = item.Book.Price
                });
            }

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Orders");
        }
    }
}
