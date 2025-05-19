namespace Lab35
{
	/// <summary>
	/// Інтерфейс, що описує здатність доставляти вантажні повітряним шляхом
	/// </summary>
	internal interface IFlyable
	{
		/// <summary>
		/// Доступність для здійнення замовлення
		/// </summary>
		bool IsAvaliable { get; }
		/// <summary>
		/// Поточне місце розташування
		/// </summary>
		Point Location { get; }

		/// <summary>
		/// Здійснення польоту
		/// </summary>
		/// <param name="destination">Місце призначення (x; y)</param>
		Task FlyAsync(Point destination);
	}
}
