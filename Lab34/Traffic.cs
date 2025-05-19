using Lab2;

namespace Lab34
{
	/// <summary>
	/// Імітує рух транспорту з певною частотою
	/// </summary>
	/// <param name="minTime">Мініальний проміжок між проїздом транспортних засобів</param>
	/// <param name="maxTime">Максимальний проміжок між ним</param>
	internal class Traffic(int minTime, int maxTime)
	{
		/// <summary>
		/// Подія, що імітує рух ноовго танспортного засобу
		/// </summary>
		public event Action? OnCarMoved;

		private readonly int minTime = minTime;
		private readonly int maxTime = maxTime;

		/// <summary>
		/// Асинзронний метод для початку роботи класу
		/// </summary>
		/// <returns></returns>
		public async Task StartAsync()
		{
			while (true)
			{
				await Task.Delay(Extensions.GetRandom().Next(minTime, maxTime));
				OnCarMoved?.Invoke();
			}
		}
	}
}
