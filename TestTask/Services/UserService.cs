using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services {
    public class UserService : IUserService {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<User> GetUser() {
            var result = _context.Users
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<List<User>> GetUsers() {
            var users = _context.Users.Where(u => u.Status == Enums.UserStatus.Inactive).ToList();
            return Task.FromResult(users);
        }
    }
}
