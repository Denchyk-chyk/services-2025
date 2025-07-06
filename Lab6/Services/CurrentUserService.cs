using Lab6.Models;

namespace Lab6.Services;

public class CurrentUserService : ICurrentUserService
{
	private readonly IUserService _userService;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public CurrentUserService(IHttpContextAccessor accessor, IUserService userService)
	{
		_httpContextAccessor = accessor;
		_userService = userService;
	}

	public async Task<User?> GetCurrentUserAsync()
	{
		var context = _httpContextAccessor.HttpContext;
		var userId = context?.Session.GetInt32("User");
		return userId.HasValue ? await _userService.GetByIdAsync(userId.Value) : null;
	}
}
