namespace Lab4;

/// <summary>
/// Інтерфейс, що містить логіку для перевірки простиз чисел
/// </summary>
internal interface IPrimesCalculator
{
	/// <summary>
	/// Метод, який повертає масив простих числе до заданого включно
	/// </summary>
	/// <param name="limit"></param>
	/// <returns></returns>
	int[] GetPrimesUpTo(int limit);

	/// <summary>
	/// Метод, який показує чи число є простим
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	bool IsPrime(int number);
}