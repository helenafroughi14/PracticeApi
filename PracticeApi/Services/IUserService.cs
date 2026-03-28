using PracticeApi.Models;

namespace PracticeApi.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(int id, User updatedUser);

        Task<bool> DeleteAsync(int id);
    }
}
