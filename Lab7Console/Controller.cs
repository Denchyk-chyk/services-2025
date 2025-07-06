using Lab7Api.Models;

namespace Lab7Console;

internal class Controller
{
	private readonly Service _service = new();

	public async Task ShowAsync()
	{
		var book = await _service.GetAsync(InputId());
		PrintBook(book);
	}

	public async Task ShowAllAsync()
	{
		Console.WriteLine("Список книг:");
		var books = await _service.GetAllAsync();

		foreach (var book in books)
		{
			PrintBook(book);
		}
	}

	public async Task AddAsync()
	{
		var created = await _service.CreateAsync(InputBook());
		Console.WriteLine("Додано книгу:");
		PrintBook(created);
	}

	public async Task EditAsync()
	{
		var success = await _service.UpdateAsync(InputId(), InputBook());
		Console.WriteLine(success ? "Книгу успішно відреадговано" : "Виникла помилка");
	}

	public async Task DeleteAsync()
	{
		var success = await _service.DeleteAsync(InputId());
		Console.WriteLine(success ? "Книгу успішно видалено" : "Виникла помилка");
	}

	private static int InputId()
	{
		Console.WriteLine("Id книги:");
		bool success = int.TryParse(Console.ReadLine(), out int value);
		return success ? value : 0;
	}

	private static InputBookDto InputBook()
	{
		var dto = new InputBookDto();

		Console.Write("Назва: ");
		dto.Title = Console.ReadLine() ?? string.Empty;

		Console.Write("Автор: ");
		dto.Author = Console.ReadLine() ?? string.Empty;

		Console.Write("Жанр: ");
		dto.Genre = Console.ReadLine() ?? string.Empty;

		Console.Write("Видавництво: ");
		dto.Publisher = Console.ReadLine() ?? string.Empty;

		Console.Write("Ціна: ");
		dto.Price = decimal.Parse(Console.ReadLine() ?? "0");

		Console.Write("Рік: ");
		dto.Year = int.Parse(Console.ReadLine() ?? "0");

		return dto;
	}

	private static void PrintBook(BookDto dto) => Console.WriteLine(
		$"{"Id:",-13} {dto.Id}\n" +
		$"{"Назва:",-13} {dto.Title}\n" +
		$"{"Автор:",-13} {dto.Author}\n" +
		$"{"Жанр:",-13} {dto.Genre}\n" +
		$"{"Видавництво:",-13} {dto.Publisher}\n" +
		$"{"Ціна:",-13} {dto.Price}\n" +
		$"{"Рік:",-13} {dto.Year}");
}

