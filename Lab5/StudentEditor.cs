using Lab32;
using System.Text.Json;

namespace Lab5
{
	/// <summary>
	/// Клас для завантаження даних про студента з файлу та їх редагування
	/// </summary>
	public class StudentEditor : IDisposable
	{
		private static readonly Dictionary<string, PropertyAdapter> properties = new()
		{
			["First name"] = new PropertyAdapter("FirstName"),
			["Last name"] = new PropertyAdapter("LastName"),
			["Gender"] = new CharPropertyAdapter("Gender"),
			["Scholarship"] = new BoollPropertyAdapter("Scholar"),
			["Birthdate"] = new DateTimePropertyAdapter("DateOfBirth"),
			["Grade"] = new DecimalPropertyAdapter("Grade"),
			["Height"] = new IntPropertyAdapter("Height"),
		};

		private static readonly JsonSerializerOptions jsonOptions = new()
		{
			WriteIndented = true
		};

		private readonly FileStream stream;
		private readonly AdvancedStudent student;

		/// <summary>
		/// Єдиний конструктор, що створює з'єднання з файлом, з якого зчтує дані про студента та куди запсиує зміни
		/// </summary>
		/// <param name="path">Шлях до файлу</param>
		public StudentEditor(string path)
		{
			stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
			stream.Seek(0, SeekOrigin.Begin); // Ставить потік на початок для зчитування всього файлу

			string data;

			using (var reader = new StreamReader(stream, leaveOpen: true))
			{
				data = reader.ReadToEnd();
			}

			if (string.IsNullOrWhiteSpace(data))
			{
				student = new();
				Console.WriteLine("New student is created");
			}
			else
			{
				student = JsonSerializer.Deserialize<AdvancedStudent>(data) ?? new AdvancedStudent();
				Console.WriteLine("Student is loaded");
			}

			Display();
		}

		// Виводить в консоль всі властивості студента
		private void Display()
		{
			var data = new List<(string name, string value)>();

			foreach (var property in properties)
			{
				string value = property.Value.Get(student);
				int size = Math.Max(value.Length, property.Key.Length);
				data.Add((property.Key.PadLeft(size), value.PadLeft(size)));
			}

			Console.WriteLine(string.Join("|", data.Select(e => e.name)));
			Console.WriteLine(string.Join("|", data.Select(e => e.value)));
		}

		/// <summary>
		/// Змінєю значення влатсивості студента
		/// </summary>
		/// <param name="name">Назва властивості</param>
		/// <param name="data">Значення</param>
		public void Edit(string name, string data)
		{
			properties[name].Set(data, student);
			Display();
		}

		/// <summary>
		/// Ручне вивільнення некерованих ресурсів користувачем
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Вивільне некерованих ресурсів через деструктор
		/// </summary>
		~StudentEditor()
		{
			Dispose(false);
		}

		/// <summary>
		/// Вивільнення некерованих ресурсів
		/// </summary>
		/// <param name="disposing">Виклкиається користувачем</param>
		protected virtual void Dispose(bool disposing)
		{
			// Звільнення некерованої пам'яті

			if (disposing) // Закриття Disposable об'єктів
			{
				stream.SetLength(0); // Очищення файлу
				stream.Seek(0, SeekOrigin.Begin); // Перехід на початок файлу

				using (var writer = new StreamWriter(stream, leaveOpen: true))
				{
					writer.Write(JsonSerializer.Serialize(student, jsonOptions)); // Запис в буфер
					writer.Flush(); // Запис у файл
				}

				stream.Close(); // Закриття з'єднання
				Console.WriteLine("Data is saved");
			}
		}
	}
}
