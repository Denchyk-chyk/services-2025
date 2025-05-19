using Lab3;

namespace Lab35
{
	/// <summary>
	/// Літак
	/// </summary>
	/// <param name="id">Унікальнйи ідентифікатор</param>
	/// <param name="speed">Швидкість руху</param>
	/// <param name="location">Стартове місце розташування<</param>
	/// <param name="colour">Колір тексту, який виводиться в консоль</param>
	internal class Plane(int id, int speed, Point location, ConsoleColor colour) : IFlyable
	{
		public bool IsAvaliable { get; private set; } = true;
		public Point Location { get; private set; } = location;

		private readonly int id = id;
		private readonly int speed = speed;
		private readonly ConsoleColor colour = colour;
		
		/// <summary>
		/// Літак летить найкоротший можливий шлях зі сталою швидкістю
		/// </summary>
		/// <param name="destination"></param>
		/// <returns></returns>
		public async Task FlyAsync(Point destination)
		{
			IsAvaliable = false;
			$"Розпочато політ із {Location}".PrintColored(colour);

			var velocity = new Point(destination.X - Location.X, destination.Y - Location.Y);
			var distance = velocity.DistanceTo(new Point(0, 0));
			velocity.X *= speed / distance;
			velocity.Y *= speed / distance;

			while (Location.DistanceTo(destination) > speed)
			{
				await Task.Delay(300);
				Location.X += velocity.X;
				Location.Y += velocity.Y;
				$"Літак #{id} летить з {Location} до {destination}".PrintColored(colour);
			}

			$"Літак #{id} прилетів до {destination}".PrintColored(colour);
			IsAvaliable = true;
		}
	}
}
