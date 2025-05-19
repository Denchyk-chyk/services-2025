using Lab1Cl;
using Lab32;
using System.Reflection;

namespace Lab5
{
	/// <summary>
	/// Getter/Setter-клас для роботи з властивістю класу AdvancedStudent
	/// Приймає і повертає дані, містить логіку для стандартизованої конвератції тексту в дані та даних в текст
	/// </summary>
	public class PropertyAdapter
	{
		private readonly PropertyInfo property;

		/// <summary>
		/// Стандартний конструктор
		/// </summary>
		/// <param name="name">Ім'я властивості</param>
		public PropertyAdapter(string name)
		{
			property = typeof(Student).GetProperty(name);
		}

		/// <summary>
		/// Конвертація рядка у дані для збереження
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		protected virtual object Read(string input) => input;

		/// <summary>
		/// Конвертація даних у рядок для виводу
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected virtual string Write(object data) => data.ToString() ?? "null";

		/// <summary>
		/// Ввід даних
		/// </summary>
		/// <param name="data">Дані</param>
		/// <param name="student">Екземпляр класу, що містить властивість</param>
		public void Set(string data, AdvancedStudent student) => property.SetValue(student, Read(data));
		
		/// <summary>
		/// Вивід даних
		/// </summary>
		/// <param name="student">Екземпляр класу, що містить властивість</param>
		/// <returns></returns>
		public string Get(AdvancedStudent student) => Write(property.GetValue(student));
	}
}
