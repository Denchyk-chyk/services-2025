using Lab1;

namespace Lab2
{
	internal static class Menu
	{
		/// <summary>
		/// Обробка помилки і її відобарження в консолі
		/// </summary>
		/// <param name="action"></param>
		/// <param name="message"></param>
		public static void HandleExeption(Action action, string message)
		{
			try
			{
				action?.Invoke();
			}
			catch (Exception e)
			{
				Console.WriteLine($"{message}. {e.Message}");
			}
		}

		/// <summary>
		/// Вивід списку в консоль
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="header"></param>
		/// <param name="collection"></param>
		public static void Write<T>(string header, ICollection<T> collection)
		{
			Display.WriteSpacer(header);

			foreach (T item in collection)
			{
				Console.WriteLine(item);
			}
		}
	}
}
