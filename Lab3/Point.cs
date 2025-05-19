namespace Lab3
{
	/// <summary>
	/// Точка у двовимірному просторі
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	internal class Point(int x, int y)
	{
		public int X { get; set; } = x;
		public int Y { get; set; } = y;
	}
}
