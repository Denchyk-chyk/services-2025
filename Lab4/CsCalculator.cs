namespace Lab4;

/// <summary>
/// Калькулятор повністю анпсианий на С#
/// </summary>
internal class CsCalculator : IPrimesCalculator
{
	public int[] GetPrimesUpTo(int limit)
	{
		List<int> primes = [];
		
		for (int i = 2; i <= limit; i++)
		{
			if (IsPrime(i))
			{
				primes.Add(i);
			}
		}

		return [.. primes];
	}

	public bool IsPrime(int number)
	{
		int sqrt = (int)Math.Sqrt(number);
		
		for (int i = 2; i <= sqrt; i++)
		{
			if (number % i == 0)
			{
				return false;
			}
		}

		return true;
	}
}
