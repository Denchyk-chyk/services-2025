using System.Globalization;

namespace Lab36
{
	internal static class Calculator
	{
		private static readonly Dictionary<char, Operation> Operations = new()
		{
			['+'] = (a, b) => a + b,
			['-'] = (a, b) => a - b,
			['*'] = (a, b) => a * b,
			['/'] = (a, b) => a / b,
		};

		/// <summary>
		/// Метод для виконання математичних операцій над двома числами на основі даних, введених в консоль
		/// </summary>
		public static void Use()
		{
			try
			{
				Console.WriteLine("Введіть короткий вираз");
				string input = Console.ReadLine()!.Replace(" ", "");

				foreach (char c in Operations.Keys)
				{
					int operatorPosition = input.IndexOf(c);

					if (operatorPosition != -1)
					{
						Console.WriteLine(Operations[c](
							int.Parse(input[..operatorPosition], CultureInfo.InvariantCulture),
							int.Parse(input[(operatorPosition + 1)..], CultureInfo.InvariantCulture)));

						return;
					}
				}

				throw new Exception("Invalid operator");
			}
			catch (Exception e)
			{
				Console.WriteLine($"Некоректно введені дані. {e.Message}");
			}
		}
	}
}
