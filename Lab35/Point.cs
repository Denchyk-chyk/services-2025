namespace Lab35
{
	/// <summary>
	/// Точка у двовимірному просторі
	/// </summary>
	/// <param name="x">Координата X</param>
	/// <param name="y">Координата Y</param>
	internal class Point(double x, double y)
	{
		public double X { get; set; } = x;
		public double Y { get; set; } = y;

		/// <summary>
		/// Розраховує скалярну відстань до іншої точки
		/// </summary>
		/// <param name="another"></param>
		/// <returns></returns>
		public double DistanceTo(Point another)
		{
			return Math.Sqrt(Math.Pow(X - another.X, 2) + Math.Pow(X - another.X, 2));
		}

		public override string ToString() => $"({X:F0}; {Y:F0})";
	}
}
