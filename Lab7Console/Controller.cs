namespace Lab7Console;

internal class Controller
{
	private readonly Service _service = new();

	public async Task ShowAsync()
	{
		var book = await _service.GetAsync(InputId());
		Console.WriteLine(book);
	}

	public async Task ShowAllAsync()
	{
		Console.WriteLine("Список книг:");
		var books = await _service.GetAllAsync();

		foreach (var book in books)
		{
			Console.WriteLine(book);
		}
	}

	public async Task AddAsync()
	{
		var input = BookDtoExtensions.Read();
		var created = _service.CreateAsync(input);
		Console.WriteLine("Додано книгу:");
		Console.WriteLine(created);
	}

	public async Task EditAsync()
	{
		var input = BookDtoExtensions.Read(InputId());
		var success = await _service.UpdateAsync(input);
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
}
