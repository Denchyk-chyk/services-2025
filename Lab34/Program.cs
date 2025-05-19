using Lab34;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

Traffic[] traffics = [new(25, 100), new(50, 250), new(70, 700)];
TrafficLight light = new((Colour.Green, 500), (Colour.Yellow, 100), (Colour.Red, 300));

Manager.Start(light, traffics);

var tasks = new List<Task>
{
	light.StartAsync()
};

foreach (var traffic in traffics)
{
	tasks.Add(traffic.StartAsync());
}

Console.Read();
Environment.Exit(0);