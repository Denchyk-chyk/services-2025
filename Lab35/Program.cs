using Lab35;
using System.Text;

Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

var airline = new Airline([.. Enumerable.Range(1, 20).Select(VehiclesFactory.CreateFlyable)]);

Client[] clients = [new(100, 1000), new(500, 1000), new(300, 900)];

foreach (var client in clients)
{
	await client.OrderAsync(airline);
}

Console.ReadLine();
Environment.Exit(0);
