namespace Lab34
{
	/// <summary>
	/// Імітує світлоофр, що змінює кольори із певно. частотою
	/// </summary>
	/// <param name="order">Масив тривалостей світіння кожного кольору</param>
	internal class TrafficLight(params (Colour, int)[] order)
	{
		/// <summary>
		/// Поточний колір
		/// </summary>
		public Colour Colour { get; private set; }

		private readonly (Colour colour, int time)[] order = order;

		/// <summary>
		/// Асинхронний запуск світлофора
		/// </summary>
		/// <returns></returns>
		public async Task StartAsync()
		{
			while (true)
			{
				foreach (var (colour, time) in order)
				{
					await Task.Delay(time);
					Colour = colour;
				}
			}
		}
	}
}
