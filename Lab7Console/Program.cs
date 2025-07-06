using Lab7Console;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var controller = new Controller();

while (true)
{
	Console.WriteLine(new string('-', 80));
	Console.WriteLine("Оберіть дію:");
	Console.WriteLine("1. Показати одну книгу");
	Console.WriteLine("2. Показати всі книги");
	Console.WriteLine("3. Додати книгу");
	Console.WriteLine("4. Редагувати книгу");
	Console.WriteLine("5. Видалити книгу");
	Console.WriteLine("0. Вийти");

	var input = Console.ReadLine();

	if (input == "0")
	{
		break;
	}

	switch (input)
	{
		case "1":
			await controller.ShowAsync();
			break;
		case "2":
			await controller.ShowAllAsync();
			break;
		case "3":
			await controller.AddAsync();
			break;
		case "4":
			await controller.EditAsync();
			break;
		case "5":
			await controller.DeleteAsync();
			break;
		default:
			Console.WriteLine("Невірний вибір, спробуйте ще раз.");
			break;
	}
}
