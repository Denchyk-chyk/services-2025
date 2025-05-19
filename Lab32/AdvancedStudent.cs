using Lab2;

namespace Lab32
{
	/// <summary>
	/// Дочірній клас ConstructableStudent з додатковими методами
	/// </summary>
	public class AdvancedStudent : ConstructableStudent
	{
		/// <summary>
		/// Основний конструктор
		/// </summary>
		/// 
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="gender"></param>
		/// <param name="scholar"></param>
		/// <param name="grade"></param>
		/// <param name="height"></param>
		/// <param name="dateOfBirth"></param>
		public AdvancedStudent (
			string firstName,
			string lastName,
			char gender,
			bool scholar,
			decimal grade,
			int height,
			DateTime dateOfBirth) :
			base(firstName, lastName, gender, scholar, grade, height, dateOfBirth)
		{

		}

		/// <summary>
		/// Порожній конструктор
		/// </summary>
		public AdvancedStudent() : base(string.Empty, string.Empty, '-', false, 0, 0, DateTime.MinValue)
		{

		}

		/// <summary>
		/// Повертає вік студента на день запиту
		/// </summary>
		/// <returns></returns>
		public int Age() => (int)((DateTime.Today - DateOfBirth).Days / 365.25);

		/// <summary>
		/// Повертає рядок з усіма даними про студента
		/// </summary>
		/// <returns></returns>
		public string FullInfo() =>
			$"{FirstName} {LastName} - ({DateOfBirth:dd.MM.yyyy} ({Age()})) | {Grade} (" +
			(Scholar ? "Державне фінансування" : "Котракт") +
			$") | Зріст {Height} см ({ImperialHeight()})";
	}
}
