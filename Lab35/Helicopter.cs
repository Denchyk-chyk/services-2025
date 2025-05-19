using Lab3;

namespace Lab35
{
	/// <summary>
	/// Гелікоптер рухається із випадковою швидкіст
	/// </summary>
	/// <param name="id">Унікальнйи ідентифікатор</param>
	/// <param name="minSpeed">Мінімальна швидкість руху</param>
	/// <param name="maxSpeed">Максимальна швидкість руху</param>
	/// <param name="location">Стартове місце розташування</param>
	/// <param name="colour">Колір тексту, який виводиться в консоль</param>
	internal class Helicopter(int id, int minSpeed, int maxSpeed, Point location, ConsoleColor colour) : IFlyable
	{
		public bool IsAvaliable { get; private set; } = true;
		public Point Location { get; private set; } = location;

		private readonly int id = id;
		private readonly int minSpeed = minSpeed;
		private readonly int maxSpeed = maxSpeed;
		private readonly ConsoleColor colour = colour;

		/// <summary>
		/// Вертоліт летить із випадковою швидкістю та лише вздовж осей (не по-діагоналі)
		/// </summary>
		/// <param name="destination"></param>
		/// <returns></returns>
		public async Task FlyAsync(Point destination)
		{
			IsAvaliable = false;
			$"Розпочато політ із {Location}".PrintColored(colour);
			Console.ResetColor();

			double remainder;

			do
			{
				await Task.Delay(300);
				var speed = Lab2.Extensions.GetRandom().Next(minSpeed, maxSpeed);
				remainder = speed;

				Location.X = Lab2.Extensions.GetRandomBool() ? Move(speed, Location.X, destination.X, out remainder) : Location.X;
				Location.Y = Move(remainder, Location.Y, destination.Y, out remainder);

				$"Вертоліт #{id} летить з {Location} до {destination}".PrintColored(colour);
			}
			while (remainder.Equals(0));

			$"Вертоліт #{id} прилетів до {destination}".PrintColored(colour);
			IsAvaliable = true;
		}

		/// <summary>
		/// Здіснює політ іж двома точками на одній осі, знаходить невикористаний запаз відстані
		/// </summary>
		/// <param name="speed"></param>
		/// <param name="location"></param>
		/// <param name="destination"></param>
		/// <param name="remainder"></param>
		/// <returns></returns>
		private static double Move(double speed, double location, double destination, out double remainder)
		{
			var delta = Math.Abs(destination - location);

			if (delta <= speed)
			{
				remainder = speed - delta;
				return destination; 
			}
			
			remainder = 0;
			return location + (speed * destination.CompareTo(location));
		}
	}
}
