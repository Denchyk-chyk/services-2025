using Lab6.Models;

namespace Lab6.Services;

public interface IUserService
{
	Task<List<User>> GetAllAsync();

	Task<User?> GetByIdAsync(int id);

	Task AddAsync(User user);

	Task UpdateAsync(User user);

	Task DeleteAsync(int id);

	Task<User?> GetByEmailAsync(string email);

	Task<User?> GetByNameAsync(string name);

	Task<User?> ValidateAsync(string login, string password);
}
