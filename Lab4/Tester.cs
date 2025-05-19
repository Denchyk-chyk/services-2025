using System.Diagnostics;

namespace Lab4;

/// <summary>
/// Клас для тестування швидкості виконання коду
/// </summary>
internal static class Tester
{
	/// <summary>
	/// Метод-бенчмарк, що виводить в консоль дані про виконання калькулятором операцій з тестовими даними /// </summary>
	/// <param name="count"></param>
	/// <param name="calculator"></param>
	public static async Task TestCalculatorAsync(int count, IPrimesCalculator calculator)
	{
		var sw = Stopwatch.StartNew();
		Task<string>[] operations =
		{
			Task.Run(() => $"{count} is " + (calculator.IsPrime(count) ? "prime" : "complex")),
			Task.Run(() => $"{calculator.GetPrimesUpTo(count).Length} primes"),
		};

		var results = await Task.WhenAll(operations);
		sw.Stop();
		Console.WriteLine($"{results[0]}\n{results[1]}\nTime {sw.ElapsedMilliseconds}ms {calculator}");
	}
}