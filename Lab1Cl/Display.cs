using System;

namespace Lab1
{
	public static class Display
	{
		public static void WriteSpacer(string header)
		{
			Console.WriteLine($"---{header.PadRight(79, '-')}");
		}
	}
}
