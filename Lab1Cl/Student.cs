using System;

namespace Lab1Cl
{
	public class Student : IComparable<Student>
	{
		//Властивості та константи
		private static int Foot = 12;
		private static double Inch = 2.54;

		public int Height { get; set; }
		public char Gender { get; set; }
		public bool Scholar { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal Grade { get; set; }
		public DateTime DateOfBirth { get; set; }

		public override string ToString()
		{
			//Форматований вивід
			return $"{FirstName} {LastName} ({DateOfBirth:dd.MM.yyyy}) - {Grade:F2}";
		}

		/// <summary>
		/// Повертає висоту в форматі "{feet}' {inches}''"
		/// </summary>
		/// <returns></returns>
		public string ImperialHeight()
		{
			//Здійснення операцій над змінними та cast
			int inches = (int)Math.Round(Height / Inch);
			int feet = inches / Foot;
			int top = inches % Foot;
			return $"{feet}' {top}''";
		}

		public int CompareTo(Student other)
		{
			//Порівняльні операції
			if (LastName.CompareTo(other.LastName) != 0)
			{
				return LastName.CompareTo(other.LastName);
			}

			if (FirstName.CompareTo(other.LastName) != 0)
			{
				return FirstName.CompareTo(other.FirstName);
			}

			return DateOfBirth.CompareTo(other.DateOfBirth);
		}
	}
}
