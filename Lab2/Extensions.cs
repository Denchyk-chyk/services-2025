using System.Globalization;

namespace Lab2
{
	public static class Extensions
	{
		/// <summary>
		/// Парсить дату у форматі "dd.MM.yyyy"
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static DateTime GetLocalDate(this string data)
		{
			return DateTime.ParseExact(data, "dd.MM.yyyy", CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Повертає новий екземпляр Random на основі Guid
		/// </summary>
		/// <returns></returns>
		public static Random GetRandom() => new(Guid.NewGuid().GetHashCode());

		/// <summary>
		/// Повертає випадкове булеве значення
		/// </summary>
		/// <returns></returns>
		public static bool GetRandomBool() => GetRandom().NextDouble() >= 0.5;

		/// <summary>
		/// Повертає випадковий елемент колекції
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static T GetRandomItem<T>(List<T> list) => list[GetRandom().Next(0, list.Count)];
	}
}
