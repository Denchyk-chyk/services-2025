using System.Runtime.InteropServices;

namespace Lab4;

/// <summary>
/// Клас для імпорту методів для перевірки простоти чисел із С++ бібліотеки
/// </summary>
internal static class Importer
{
	/// <summary>
	/// Повертає true якщо число просте
	/// </summary>
	/// <param name="n"></param>
	/// <returns></returns>
	[DllImport("Lab4Dll.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern bool is_prime(int n);

	/// <summary>
	/// Записує всі прості числа до заданого в існуючий масив розмір, якого потрібно явно вказати /// Повертає кількість чих чисел
	/// </summary>
	/// <param name="limit">Чисдо</param>
	/// <param name="output_array">Масив, у який здійснюватиметься запис</param>
	/// <param name="max_count">Довжина цього масиву</param>
	/// <returns></returns>
	[DllImport("Lab4Dll.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern int get_primes_up_to(int limit, [Out] int[] output_array, int max_count);
}