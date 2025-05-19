namespace Lab35
{
	/// <summary>
	/// Клас, що містить фабричний метод
	/// </summary>
	internal static class VehiclesFactory
	{
		/// <summary>
		/// Фабричний метод для створення літального засобу залежно від вхідний даних
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static IFlyable CreateFlyable(int index)
		{
			if (index % 5 == 0)
			{
				return new Helicopter(
					index,
					Lab2.Extensions.GetRandom().Next(10, 50), 
					Lab2.Extensions.GetRandom().Next(50, 150), 
					Extensions.GetRandomPoint(),
					Lab3.Extensions.GetRandomColour());
			}
			else
			{
				return new Plane(
					index, 
					Lab2.Extensions.GetRandom().Next(10, 100), 
					Extensions.GetRandomPoint(),
					Lab3.Extensions.GetRandomColour());
			}
		}
	}
}
