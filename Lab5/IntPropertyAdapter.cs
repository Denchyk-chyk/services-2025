using System.Globalization;

namespace Lab5
{
	/// <summary>
	/// Версія суперкласу для роботи ів цілочисельниими властивостями
	/// </summary>
	/// <param name="name"></param>
	public class IntPropertyAdapter(string name) : PropertyAdapter(name)
	{
		protected override object Read(string input) => int.Parse(input, CultureInfo.InvariantCulture);
	}
}
