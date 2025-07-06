using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.ViewComponents;

public class UserStatusViewComponent : ViewComponent
{
	private readonly IUserService _userService;
	private readonly IHttpContextAccessor _accessor;

	public UserStatusViewComponent(IUserService userService, IHttpContextAccessor accessor)
	{
		_userService = userService;
		_accessor = accessor;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var userId = _accessor.HttpContext?.Session.GetInt32("User");

		if (userId is int id)
		{
			var user = await _userService.GetByIdAsync(id);
			return View("LoggedIn", user?.Name);
		}

		return View("LoggedOut");
	}
}
