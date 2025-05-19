namespace Lab35
{
	/// <summary>
	/// Імітує здійсненя замовлен до авіакомпанії з установленою частотою
	/// </summary>
	/// <param name="minTime">Мінміальний проміжок між замовленнями (мс)</param>
	/// <param name="maxTime">Максимальний проміжок між замовленнями (мс)</param>
	internal class Client(int minTime, int maxTime)
	{
		private readonly int minTime = minTime;
		private readonly int maxTime = maxTime;

		/// <summary>
		/// Здійснення замовлення до авіакомпанії (асинхронний метод)
		/// </summary>
		/// <param name="airline"></param>
		/// <returns></returns>
		public async Task OrderAsync(Airline airline)
		{
			var destination = Extensions.GetRandomPoint();
			Console.WriteLine($"Замовлено рейс на {destination}");
			airline.Move(destination);
			await Task.Delay(Lab2.Extensions.GetRandom().Next(minTime, maxTime));
			await OrderAsync(airline);
		}
	}
}
