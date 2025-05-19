namespace Lab35
{
	/// <summary>
	/// Імітує авіакомпанію, що здійснює вантажопереревзення
	/// </summary>
	/// <param name="vehicles"></param>
	internal class Airline(params IFlyable[] vehicles)
	{
		/// <summary>
		/// Перелік наявних літаючих транспортних засобів
		/// </summary>
		private readonly IFlyable[] vehicles = vehicles;

		/// <summary>
		/// Відправляє найближчий літаючий засіб до місця призначення
		/// </summary>
		/// <param name="destination"></param>
		/// <returns></returns>
		public async Task Move(Point destination)
		{
			var distance = vehicles.Select(v => v.Location.DistanceTo(destination)).Min();
			var closest = vehicles.First(v => v.Location.DistanceTo(destination).Equals(distance));
			await closest.FlyAsync(destination);
		}
	}
}
