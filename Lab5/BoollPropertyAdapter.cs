namespace Lab5
{
	/// <summary>
	/// Версія суперкласу для роботи з булевии властивостями у форматі +/-
	/// </summary>
	/// <param name="name"></param>
	internal class BoollPropertyAdapter(string name) : PropertyAdapter(name)
	{
		protected override object Read(string input) => input == "+";

		protected override string Write(object data) => ((bool)data) ? "+" : "-";
	}
}