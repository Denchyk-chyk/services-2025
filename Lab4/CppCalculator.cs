namespace Lab4;

/// <summary>
/// Калькулятор, що використовує C++ бібліотеку
/// </summary>
internal class CppCalculator : IPrimesCalculator
{
	public int[] GetPrimesUpTo(int limit)
	{
		if (limit < 2) return [];

		var buffer = new int[limit];
		int count = Importer.get_primes_up_to(limit, buffer, buffer.Length);

		var result = new int[count];
		Array.Copy(buffer, result, count);
		return result;
	}

	public bool IsPrime(int number) => Importer.is_prime(number);
}
