using Lab1Cl;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lab2
{
	internal static class Loader
	{
		/// <summary>
		/// Завантажує дані з файлу із записаим у форматі JSON
		/// </summary>
		/// <param name="source">JSON-файл</param>
		/// <returns></returns>
		public static List<Student> Load(string source)
		{
			var data = File.ReadAllLines(source);
			return [.. data.Select(e => JsonSerializer.Deserialize<Student>(e))];
		}

		/// <summary>
		/// Генерує дані на основі XML-файлу
		/// </summary>
		/// <param name="source">XML-файл</param>
		/// <param name="count">Кількість записів</param>
		/// <returns></returns>
		public static List<Student> Generate(string source, int count)
		{
			var data = 
				new XmlSerializer(typeof(StudentsGenerationData)).Deserialize(new StreamReader(source))
				as StudentsGenerationData;

			var students = new List<Student>();

			for (int i = 0; i < count; i++)
			{
				var male = Extensions.GetRandomBool();
				IntegersRange height = male ? data!.Heights.Male : data!.Heights.Female;

				students.Add(new ConstructableStudent(
					Extensions.GetRandomItem(data.FirstNames),
					Extensions.GetRandomItem(data.LastNames),
					male ? 'M' : 'F',
					Extensions.GetRandomBool(),
					//min + (max - min) * [0; 1)
					data.Mark.Min + ((decimal)Extensions.GetRandom().NextDouble() * (data.Mark.Max - data.Mark.Min)),
					Extensions.GetRandom().Next(height.Min, height.Max),
					//min + (max - min) * [0; 1)
					data.DateOfBirth.Min.AddDays((data.DateOfBirth.Max - data.DateOfBirth.Min).Days * Extensions.GetRandom().NextDouble())));
			}

			return students;
		}

		/// <summary>
		/// Зберігає дані у файл із JSON-записами (дописує до наявних даних)
		/// </summary>
		/// <param name="students">Дані</param>
		/// <param name="path">Вихідний файл</param>
		public static void Save(List<Student> students, string path)
		{
			var writer = new StreamWriter(path, append: true);

			foreach (var student in students)
			{
				writer.WriteLine(JsonSerializer.Serialize(student));
			}

			writer.Close();
		}
	}
}
