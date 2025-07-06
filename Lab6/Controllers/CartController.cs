using Lab6.Filters;
using Lab6.Models;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab6.Controllers;

/// <summary>
/// Контролер для роботи з кошиком покупок.
/// </summary>
[Route("cart")]
public class CartController(IFruitService fruitService) : Controller
{
	// Сервіс для роботи з фруктами
	private readonly IFruitService _fruitService = fruitService;

	// Словник для збереження ідентифікаторів фруктів і їх кількості
	private Dictionary<int, int> _fruits = [];

	/// <summary>
	/// Відображення вмісту кошика.
	/// Завантажуються дані з сесії, після чого отримуються деталі фруктів.
	/// </summary>
	/// <returns>Представлення з картою фруктів та їх кількістю.</returns>
	[HttpGet("")]
	[AuthorizedFilter]
	public async Task<IActionResult> IndexAsync()
	{
		LoadFruits();

		var result = new Dictionary<Fruit, int>();

		// Для кожного фрукта у кошику отримується детальна інформація
		foreach (var (id, count) in _fruits)
		{
			var fruit = await _fruitService.GetByIdAsync(id);
			if (fruit is not null)
			{
				result[fruit] = count;
			}
		}

		return View(result);
	}

	/// <summary>
	/// Додавання фрукта у кошик.
	/// Кількість фрукта збільшується на одиницю.
	/// </summary>
	/// <param name="fruit">Ідентифікатор фрукта.</param>
	/// <returns>Порожня відповідь (200 OK).</returns>
	[HttpPost("add")]
	public IActionResult Add(int fruit)
	{
		LoadFruits();

		// Оновлення кількості: якщо фрукт є, збільшується, інакше встановлюється 1
		_fruits[fruit] = 1 + (_fruits.TryGetValue(fruit, out int count) ? count : 0);

		SaveFruits();

		return Ok();
	}

	/// <summary>
	/// Видалення фрукта з кошика.
	/// </summary>
	/// <param name="fruit">Ідентифікатор фрукта.</param>
	/// <returns>Перенаправлення на сторінку кошика.</returns>
	[HttpPost("remove")]
	[AuthorizedFilter]
	public IActionResult Remove(int fruit)
	{
		LoadFruits();

		// Видалення позиції з кошика
		_fruits.Remove(fruit);

		SaveFruits();

		return RedirectToAction("Index");
	}

	/// <summary>
	/// Очищення кошика.
	/// </summary>
	/// <returns>Перенаправлення на сторінку зі списком фруктів.</returns>
	[HttpPost("clear")]
	[AuthorizedFilter]
	public IActionResult Clear()
	{
		// Очищення локального словника
		_fruits.Clear();

		SaveFruits();

		return RedirectToAction("Index", "Fruits");
	}

	/// <summary>
	/// Отримання загальної кількості фруктів у кошику.
	/// </summary>
	/// <returns>JSON з полем count.</returns>
	[HttpGet("count")]
	public IActionResult Count()
	{
		LoadFruits();

		// Підрахунок сумарної кількості
		int count = _fruits.Values.Sum();

		return Json(new { count });
	}

	/// <summary>
	/// Збереження стану кошика у сесію у вигляді JSON.
	/// </summary>
	private void SaveFruits()
	{
		HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(_fruits));
	}

	/// <summary>
	/// Завантаження стану кошика зі сесії.
	/// Якщо дані відсутні — ініціалізується порожній словник.
	/// </summary>
	private void LoadFruits()
	{
		var cartJson = HttpContext.Session.GetString("Cart");

		if (!string.IsNullOrEmpty(cartJson))
		{
			_fruits = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson) ?? [];
		}
	}
}
