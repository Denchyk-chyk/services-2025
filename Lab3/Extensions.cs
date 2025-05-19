namespace Lab3
{
	/// <summary>
	/// Набір методів розширень
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// Створює випадковий колір для тексту в консолі (крім чорного та білого)
		/// </summary>
		/// <returns></returns>
		public static ConsoleColor GetRandomColour()
		{
			var colour = (ConsoleColor)Lab2.Extensions.GetRandom().Next(0, Enum.GetValues(typeof(ConsoleColor)).Length);

			if (colour == ConsoleColor.Black || colour == ConsoleColor.White)
			{
				return GetRandomColour();
			}

			return colour;
		}

		/// <summary>
		/// Виводить в консоль текси з певним кольором
		/// </summary>
		/// <param name="message"></param>
		/// <param name="colour"></param>
		/// <param name="returnBack">Чи повертати колір тексту до стандратного після виводу</param>
		public static void PrintColored(this string message, ConsoleColor colour, bool returnBack = true)
		{
			Console.ForegroundColor = colour;
			Console.WriteLine(message);
			if (returnBack)
			{
				Console.ResetColor();
			}
		}
	}
}
