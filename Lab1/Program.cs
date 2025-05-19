using Lab1Cl;
using Lab1Vb.Lab1;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lab1
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			//Завдання 2
			Display.WriteSpacer("Task 2");

			var firstStudent = new Student();
			firstStudent.FirstName = "Melnyk";
			firstStudent.LastName = "Olexandra";
			firstStudent.Gender = 'F';
			firstStudent.Scholar = false;
			firstStudent.Height = 162;
			firstStudent.Grade = 78.89m;
			firstStudent.DateOfBirth = new DateTime(2005, 3, 17, 0, 0, 0, DateTimeKind.Local);

			var secondStudent = new Student()
			{
				FirstName = "Denys",
				LastName = "Khimi",
				Gender = 'M',
				Scholar = true,
				Height = 182,
				Grade = 81.27m,
				DateOfBirth = DateTime.ParseExact("13.06.2005", "dd.MM.yyyy", CultureInfo.InvariantCulture),
			};

			Console.WriteLine(firstStudent);
			Console.WriteLine(secondStudent);

			Console.WriteLine($"{firstStudent.ImperialHeight()} | {secondStudent.ImperialHeight()}");

			//Завдання 3
			Display.WriteSpacer("Task 3");
			var data = new (string, string, char, bool, int, decimal, string)[]
			{
				("Anna", "Shevchenko", 'F', false, 167, 76.5m, "02.03.2004"),
				("Max", "Bondar", 'M', true, 178, 88.2m, "25.12.2003"),
				("Iryna", "Datsenko", 'F', false, 160, 69.9m, "11.09.2004"),
				("Oleh", "Tkachuk", 'M', true, 185, 91.3m, "30.07.2005"),
				("Kateryna", "Hlushko", 'F', true, 172, 85.0m, "14.02.2005"),
				("Andriy", "Melnyk", 'M', false, 175, 70.4m, "21.05.2004"),
				("Olena", "Krut", 'F', true, 165, 93.8m, "08.11.2003"),
				("Vitalii", "Sydorenko", 'M', false, 180, 66.7m, "17.08.2005"),
				("Mariia", "Poliakova", 'F', true, 169, 82.1m, "29.06.2004"),
				("Dmytro", "Zhuk", 'M', false, 177, 74.6m, "01.01.2005"),
				("Sofiia", "Levchenko", 'F', true, 163, 89.9m, "10.10.2004"),
				("Ivan", "Stepanenko", 'M', true, 186, 90.0m, "06.12.2003"),
				("Viktoriia", "Romanenko", 'F', false, 170, 71.2m, "23.04.2005"),
				("Artem", "Kovalchuk", 'M', true, 179, 84.5m, "03.03.2004"),
				("Yuliia", "Havryliuk", 'F', true, 164, 79.3m, "26.05.2005"),
				("Taras", "Berezovskyi", 'M', false, 181, 67.8m, "15.09.2004"),
				("Anastasiia", "Shynkarenko", 'F', true, 168, 92.4m, "04.07.2003"),
				("Yehor", "Pavlenko", 'M', true, 183, 88.6m, "12.08.2004"),
				("Natalia", "Voloshyna", 'F', false, 162, 73.1m, "30.10.2005"),
				("Roman", "Kovtun", 'M', false, 176, 65.5m, "07.02.2005"),
				("Liliia", "Honcharenko", 'F', true, 171, 86.0m, "18.06.2004"),
				("Serhii", "Yurchenko", 'M', false, 184, 72.9m, "09.01.2005"),
				("Alina", "Panchuk", 'F', true, 166, 90.7m, "28.11.2003"),
				("Oleksandr", "Mazur", 'M', true, 187, 95.2m, "13.03.2004"),
				("Zoriana", "Kuzmenko", 'F', false, 158, 68.4m, "19.04.2005"),
			};

			var students = data.Select(e => new Student()
			{
				FirstName = e.Item1,
				LastName = e.Item2,
				Gender = e.Item3,
				Scholar = e.Item4,
				Height = e.Item5,
				Grade = e.Item6,
				DateOfBirth = DateTime.ParseExact(e.Item7, "dd.MM.yyyy", CultureInfo.InvariantCulture),
			}).ToList();

			//Додавання
			students.Add(firstStudent);
			students.Insert(0, firstStudent);

			//Видалення
			students.RemoveAt(0);
			students.Remove(firstStudent);
			students.RemoveAll(e => e.Grade < 75);

			//Сорутвання та вивід
			students.Sort();
			foreach (var student in students)
			{
				Console.WriteLine(student);
			}

			Display.WriteSpacer(string.Empty);

			students.Sort((x, y) => y.Grade.CompareTo(x.Grade));
			for (int i = 0; i < students.Count; i++)
			{
				Console.WriteLine(students[i]);
			}

			//Завдання 4
			Display.WriteSpacer("Task 4");
			
			string path = @"C:\Users\denys\OneDrive\Документи\Навчання\ІФНТУНГ\3 Курс\2 Семестр\Новітні інформаційні сервіси\Лабораторні\Звіти\Лабораторна 1\Студенти.txt";

			try
			{
				//Зчитування студентів з файлу
				var reader = File.ReadAllLines(path);
			
				students = reader.Select(e =>
				{
					var splitted = e.Split();
					return new Student()
					{
						FirstName = splitted[0],
						LastName = splitted[1],
						Gender = splitted[2].ToUpper()[0],
						Scholar = bool.Parse(splitted[3]),
						Height = int.Parse(splitted[4], CultureInfo.InvariantCulture),
						Grade = decimal.Parse(splitted[5], CultureInfo.InvariantCulture),
						DateOfBirth = DateTime.ParseExact(splitted[6], "dd.MM.yyyy", CultureInfo.InvariantCulture),
					};
				}).ToList();

				foreach (var student in students)
				{
					Console.WriteLine(student);
				}

				//Запис студентів у файл
				try
				{
					var writer = new StreamWriter(path, append: true);

					var newStudents = new Student[]
					{
					firstStudent, secondStudent
					};

					foreach (var student in newStudents)
					{
						writer.WriteLine(
							$"{student.FirstName} " +
							$"{student.LastName} " +
							$"{student.Gender} " +
							$"{student.Scholar} " +
							$"{student.Height} " +
							$"{student.Grade.ToString(CultureInfo.InvariantCulture)} " +
							$"{student.DateOfBirth:dd.MM.yyyy}");
					}

					writer.Close();

				}
				catch (Exception e)
				{
					Console.WriteLine($"Не вдалося записати дані у файл. {e.Message}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Не вдалося відкрити файл. {e.Message}");
			}

			//Завдання 5
			Display.WriteSpacer("Task 5");
			IClsCompliant cs = new ClsCompliantCs(), vb = new ClsCompliantVb();

			UseClsCompliant(cs);
			UseClsCompliant(vb);
		}

		private static void UseClsCompliant(IClsCompliant compliant)
		{
			char[] text = "Hello world".ToCharArray();
			int[] numebrs = new int[] { 24, 235, 25, 26, 34, 74, 5 };

			Console.WriteLine($"{compliant.Average(numebrs)} | {compliant.Merge(text)}");
		}
	}
}
