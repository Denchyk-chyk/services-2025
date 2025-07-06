using Lab6.Models;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

/// <summary>
/// Контролер Web API для адміністративних дій з фруктами.
/// Дозволяє перегляд, додавання, оновлення та видалення фруктів.
/// Доступ до методів зміни даних обмежено лише для адміністраторів.
/// </summary>
[ApiController]
[Route("api/admin/fruits")]
public class AdminFruitsApiController(IFruitService fruitService, IUserService userService) : ControllerBase
{
	/// <summary>
	/// Сервіс для взаємодії з даними фруктів.
	/// </summary>
	private readonly IFruitService _fruitService = fruitService;

	/// <summary>
	/// Сервіс для доступу до користувачів (потрібен для перевірки прав).
	/// </summary>
	private readonly IUserService _userService = userService;

	/// <summary>
	/// Отримати список усіх фруктів.
	/// </summary>
	/// <returns>Список фруктів у форматі JSON.</returns>
	[HttpGet("get")]
	public async Task<ActionResult<IEnumerable<Fruit>>> GetAll()
	{
		var fruits = await _fruitService.GetAllAsync();
		return Ok(fruits);
	}

	/// <summary>
	/// Отримати фрукт за його ідентифікатором.
	/// </summary>
	/// <param name="id">ID фрукта.</param>
	/// <returns>Фрукт або помилка 404, якщо не знайдено.</returns>
	[HttpGet("get/{id}")]
	public async Task<ActionResult<Fruit>> GetById(int id)
	{
		var fruit = await _fruitService.GetByIdAsync(id);
		if (fruit == null)
		{
			return NotFound();
		}

		return Ok(fruit);
	}

	/// <summary>
	/// Додати новий фрукт. Тільки для адміністратора.
	/// </summary>
	/// <param name="fruit">Обʼєкт фрукта з тіла запиту.</param>
	/// <returns>Код 200 або 403, якщо немає прав.</returns>
	[HttpPost("add")]
	public async Task<IActionResult> Add([FromBody] Fruit fruit)
	{
		if (!IsAdmin()) return Forbid();

		await _fruitService.AddAsync(fruit);
		return Ok();
	}

	/// <summary>
	/// Оновити дані фрукта. Тільки для адміністратора.
	/// </summary>
	/// <param name="fruit">Оновлений фрукт.</param>
	/// <returns>Код 200 або 403, якщо немає прав.</returns>
	[HttpPut("update")]
	public async Task<IActionResult> Update([FromBody] Fruit fruit)
	{
		if (!IsAdmin()) return Forbid();

		await _fruitService.UpdateAsync(fruit);
		return Ok();
	}

	/// <summary>
	/// Видалити фрукт за ID. Тільки для адміністратора.
	/// </summary>
	/// <param name="id">ID фрукта.</param>
	/// <returns>Код 200 або 403, якщо немає прав.</returns>
	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		if (!IsAdmin()) return Forbid();

		await _fruitService.DeleteAsync(id);
		return Ok();
	}

	/// <summary>
	/// Перевірити, чи поточний користувач має права адміністратора.
	/// </summary>
	/// <returns>True – якщо користувач є адміністратором; інакше – false.</returns>
	private bool IsAdmin()
	{
		var userId = HttpContext.Session.GetInt32("User");
		if (userId is not int id) return false;

		var user = _userService.GetByIdAsync(id).Result;
		return user?.IsAdmin == true;
	}
}
