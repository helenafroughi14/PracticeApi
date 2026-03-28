using Microsoft.EntityFrameworkCore;
using PracticeApi.Data;
using PracticeApi.Models;

namespace PracticeApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(int id, User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
                return null;

            //update fields
            existingUser.Name = updatedUser.Name;

            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var removeUser = await _context.Users.FindAsync(id);

            if (removeUser == null)
            {
                return false;
            }

            _context.Users.Remove(removeUser);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}