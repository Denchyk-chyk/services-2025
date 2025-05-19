namespace Lab35
{
	/// <summary>
	/// Набір статичних методів розширенння
	/// </summary>
	internal static class Extensions
	{
		/// <summary>
		/// Створює випадкову точку на площині
		/// </summary>
		/// <returns></returns>
		public static Point GetRandomPoint() => new(GetRandomCoordinate(), GetRandomCoordinate());

		/// <summary>
		/// Створює випадкове число в межах [10 000; -10 000)
		/// </summary>
		/// <returns></returns>
		private static int GetRandomCoordinate() => (int)(Lab2.Extensions.GetRandom().NextDouble() * 10_000);
	}
}
