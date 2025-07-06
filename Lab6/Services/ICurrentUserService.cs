using Lab6.Models;

namespace Lab6.Services;

public interface ICurrentUserService
{
	Task<User?> GetCurrentUserAsync();
}
