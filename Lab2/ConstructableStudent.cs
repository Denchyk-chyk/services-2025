using Lab1Cl;

namespace Lab2
{
	public class ConstructableStudent : Student
	{
		public ConstructableStudent(
			string firstName, 
			string lastName, 
			char gender, 
			bool scholar, 
			decimal grade, 
			int height,
			DateTime dateOfBirth) : base()
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Gender = gender;
			this.Scholar = scholar;
			this.Grade = grade;
			this.Height = height;
			this.DateOfBirth = dateOfBirth;
		}
	}
}
