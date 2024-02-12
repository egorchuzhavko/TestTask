using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services {
    public class OrderService : IOrderService {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context) {
            _context = context;
        }
        public Task<Order> GetOrder() {
            var order = _context.Orders
                .OrderByDescending(o => o.Price * o.Quantity)
                .FirstOrDefault();
            return Task.FromResult(order);
        }

        public Task<List<Order>> GetOrders() {
            var orders = _context.Orders
                .Where(o => o.Quantity > 10)
                .ToList();
            return Task.FromResult(orders);
        }
    }
}
