using Lab4;
using System.Globalization;

while (true)
{
	Console.WriteLine("Number");
	int count = int.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
	Console.WriteLine("Input \"+\" to start C++ version first or \"#\" to start C# version first");
	bool plusFirst = (Console.ReadLine() ?? "+")[0] == '+';
	
	Task[] tasks =
	{
		Tester.TestCalculatorAsync(count, plusFirst ? new CppCalculator() : new CsCalculator()), 
		Tester.TestCalculatorAsync(count, plusFirst ? new CsCalculator() : new CppCalculator()),
	};
	await Task.WhenAll(tasks);
}
