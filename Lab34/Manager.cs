using Lab3;

namespace Lab34
{
	/// <summary>
	/// Клас, що реагує на дорожній трафік вулиці залежно від кольору світлофора
	/// </summary>
	internal static class Manager
	{
		/// <summary>
		/// Підклчення до світлофора та джерел дорожнього трафіку
		/// </summary>
		/// <param name="light"></param>
		/// <param name="traffics"></param>
		public static void Start(TrafficLight light, params Traffic[] traffics)
		{
			foreach (var traffic in traffics)
			{
				traffic.OnCarMoved += () => React(light);
			}
		}

		/// <summary>
		/// Повідомлення про порушення вразі проїзду у невідповідий час
		/// </summary>
		/// <returns></returns>
		public static void React(TrafficLight light)
		{
			switch (light.Colour)
			{
				case Colour.Yellow:
					$"Проїзд на жовте світло {DateTime.Now}".PrintColored(ConsoleColor.Yellow, false);
					return;
				case Colour.Red:
					$"Проїзд на червоне світло {DateTime.Now}".PrintColored(ConsoleColor.Red, false);
					return;
			}
		}
	}
}
