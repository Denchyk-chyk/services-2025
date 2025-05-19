using Lab32;
using System.Globalization;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var firstStudent = new AdvancedStudent
	("Denys", "Khimii", 'M', true, 81.27m, 182, DateTime.ParseExact("13.06.2005", "dd.MM.yyyy", CultureInfo.InvariantCulture));

var secondStudent = new AdvancedStudent
	("Melnyk", "Olexandra", 'F', false, 79.27m, 162, new DateTime(2005, 3, 17, 0, 0, 0, DateTimeKind.Local));

Console.WriteLine(firstStudent);
Console.WriteLine(secondStudent);

Console.WriteLine($"{firstStudent.ImperialHeight()} | {secondStudent.ImperialHeight()}");
Console.WriteLine($"{firstStudent.Age()} рр. | {secondStudent.Age()} рр.");

firstStudent.Height += 2;
secondStudent.Grade = 80.03m;
secondStudent.Scholar = true;

Console.WriteLine(firstStudent.FullInfo());
Console.WriteLine(secondStudent.FullInfo());