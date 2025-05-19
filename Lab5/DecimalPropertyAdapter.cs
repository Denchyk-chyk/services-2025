using System.Globalization;

namespace Lab5
{
	/// <summary>
	/// Версія суперкласу для роботи із властивостями у форматі чисел з плаваючою комою
	/// </summary>
	/// <param name="name"></param>
	internal class DecimalPropertyAdapter(string name) : PropertyAdapter(name)
	{
		protected override object Read(string input) => decimal.Parse(input, CultureInfo.InvariantCulture);

		protected override string Write(object data) => ((decimal)data).ToString("F2");
	}
}
