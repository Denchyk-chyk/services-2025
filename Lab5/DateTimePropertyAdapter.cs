using System.Globalization;

namespace Lab5
{
	/// <summary>
	/// Версія суперкласу для роботи з властивостями дати і часу в європейському форматі
	/// </summary>
	/// <param name="name"></param>
	internal class DateTimePropertyAdapter(string name) : PropertyAdapter(name)
	{
		protected override object Read(string input) => DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);

		protected override string Write(object data) => ((DateTime)data).ToString("dd.MM.yyyy");
	}
}