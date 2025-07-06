using Lab7Api.Models;
using System.Text;
using System.Text.Json;

namespace Lab7Console
{
	internal static class BookDtoExtensions
	{
		public static StringContent ToJsonContent(this InputBookDto dto) => new(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

		public static InputBookDto Read()
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

		public static void Show(this BookDto dto) => Console.WriteLine(
			$"{"Id:",-13} {dto.Id}\n" +
			$"{"Назва:",-13} {dto.Title}\n" +
			$"{"Автор:",-13} {dto.Author}\n" +
			$"{"Жанр:",-13} {dto.Genre}\n" +
			$"{"Видавництво:",-13} {dto.Publisher}\n" +
			$"{"Ціна:",-13} {dto.Price}\n" +
			$"{"Рік:",-13} {dto.Year}");
	}
}
