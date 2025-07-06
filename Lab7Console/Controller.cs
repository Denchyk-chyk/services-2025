namespace Lab7Console;

internal class Controller
{
	private readonly Service _service = new();

	public async Task ShowAsync()
	{
		var book = await _service.GetAsync(InputId());
		book.Show();
	}

	public async Task ShowAllAsync()
	{
		Console.WriteLine("Список книг:");
		var books = await _service.GetAllAsync();

		foreach (var book in books)
		{
			book.Show();
		}
	}

	public async Task AddAsync()
	{
		var created = await _service.CreateAsync(BookDtoExtensions.Read());
		Console.WriteLine("Додано книгу:");
		created.Show();
	}

	public async Task EditAsync()
	{
		var success = await _service.UpdateAsync(InputId(), BookDtoExtensions.Read());
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
