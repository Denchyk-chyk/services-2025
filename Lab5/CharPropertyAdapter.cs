namespace Lab5
{
	/// <summary>
	/// Версія суперкласу для роботи з символьниими властивостями
	/// </summary>
	/// <param name="name"></param>
	internal class CharPropertyAdapter(string name) : PropertyAdapter(name)
	{
		protected override object Read(string input) => input[0];

		protected override string Write(object data) => data.ToString().ToUpper();
	}
}
