using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

/// <summary>
/// Обробка запитів, пов'язаних із автентифікацією користувача.
/// </summary>
[Route("authorization")]
public class AuthorizationController(IUserService userService) : Controller
{
	// Ін'єкція сервісу користувачів для взаємодії з даними про користувачів
	private readonly IUserService _userService = userService;

	/// <summary>
	/// Відображення сторінки входу.
	/// </summary>
	[HttpGet("")]
	public IActionResult Index()
	{
		return View();
	}

	/// <summary>
	/// Обробка запиту на вхід користувача.
	/// </summary>
	/// <param name="login">Ім’я користувача або email.</param>
	/// <param name="password">Пароль користувача.</param>
	/// <returns>Перенаправлення на головну сторінку або повторне відображення форми входу з повідомленням про помилку.</returns>
	[HttpPost("login")]
	public async Task<IActionResult> Login(string login, string password)
	{
		// Перевірка облікових даних
		var user = await _userService.ValidateAsync(login, password);

		// Обробка невдалої автентифікації
		if (user is null)
		{
			ModelState.AddModelError("", "Неправильний логін або пароль");
			return View("Index");
		}

		// Збереження ідентифікатора користувача в сесію
		HttpContext.Session.SetInt32("User", user.Id);

		// Перенаправлення до списку фруктів
		return RedirectToAction("Index", "Fruits");
	}

	/// <summary>
	/// Обробка запиту на вихід користувача.
	/// </summary>
	/// <returns>Перенаправлення на попередню сторінку.</returns>
	[HttpPost("logout")]
	public IActionResult Logout()
	{
		// Видалення користувача з сесії
		HttpContext.Session.Remove("User");

		// Перенаправлення назад
		return Redirect(Request.Headers["Referer"]);
	}
}
