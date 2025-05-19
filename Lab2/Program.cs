using Lab1Cl;
using Lab2;
using System.Globalization;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var logger = new Logger();
var students = new List<Student>();

var commands = new List<Action<string>>
{
	(input) =>
	{
		Menu.HandleExeption(() =>
		{
			students = Loader.Load(input.Trim('"'));
			logger.Log(Operation.Load);
			Menu.Write($"Завантажено студентів - {students.Count}", students);
		},
		"Помилка при зчитуванні даних з JSON-файлу");
	},
	(input) =>
	{
		Menu.HandleExeption(() =>
		{
			int space = input.IndexOf('"') + 1;
			students = Loader.Generate(
				input.Substring(0, space).Trim('"'), 
				int.Parse(input.Substring(space + 1), CultureInfo.InvariantCulture));
			logger.Log(Operation.Generate);
			Menu.Write($"Згенеровано студентів - {students.Count}", students);
		},
		"Помилка при зчитуванні даних з XML-файлу");
	},
	(input) =>
	{
		Menu.HandleExeption(() =>
		{
			if (students.Count == 0)
			{
				Console.WriteLine($"Немає даних для збереження");
			}
			else
			{
				Loader.Save(students, input.Trim('"'));
				logger.Log(Operation.Save);
				Menu.Write($"Збережено студентів - {students.Count}", students);
			}
		},
		"Помилка при записі даних в JSON-файл");
	},
	(input) =>
	{
		Menu.Write("Операції", logger.Logs.Select(l => new LogView(l)).ToList());
	},
	(input) => Environment.Exit(0)
};

while (true)
{
	Console.WriteLine(
		"Виберіть дію\n" +
		"1. Завантажити дані {шлях}\n" +
		"2. Згенерувати дані {шлях} {кількість}\n" +
		"3. Зберегти дані {шлях}\n" +
		"4. Показати журнал дій\n" +
		"5. Вийти");

	var input = Console.ReadLine();

	try
	{
		commands[int.Parse(input![0].ToString(), CultureInfo.InvariantCulture) - 1](input.Length > 2 ? input.Substring(3) : string.Empty);
	}
	catch
	{
		Console.WriteLine("Некоректно введена команда");
	}
}