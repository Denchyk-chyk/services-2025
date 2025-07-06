using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
	/// <summary>
	/// Контролер для роботи з фруктами: перегляд списку та деталей.
	/// </summary>
	public class FruitsController : Controller
	{
		// Сервіс для роботи з даними фруктів
		private readonly IFruitService _fruitService;

		/// <summary>
		/// Конструктор із впровадженням сервісу фруктів.
		/// </summary>
		/// <param name="fruitService">Сервіс фруктів.</param>
		public FruitsController(IFruitService fruitService)
		{
			_fruitService = fruitService;
		}

		/// <summary>
		/// Отримання списку всіх фруктів.
		/// </summary>
		/// <returns>Представлення зі списком фруктів.</returns>
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var fruits = await _fruitService.GetAllAsync();
			return View(fruits);
		}

		/// <summary>
		/// Отримання детальної інформації про фрукт за ідентифікатором.
		/// </summary>
		/// <param name="id">Ідентифікатор фрукта.</param>
		/// <returns>Представлення з інформацією про фрукт або 404, якщо не знайдено.</returns>
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var fruit = await _fruitService.GetByIdAsync(id);

			if (fruit == null)
			{
				return NotFound();
			}

			return View(fruit);
		}
	}
}
