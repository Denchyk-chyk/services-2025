namespace Lab2
{
	internal class LogView
	{
		public static Dictionary<Operation, string> Names { get; } = new Dictionary<Operation, string>()
		{
			[Operation.Load] = "Завантаження",
			[Operation.Generate] = "Генерація",
			[Operation.Save] = "Збереження",
		};

		private int Length { get; }
		private Log Log { get; }

		public LogView(Log log)
		{
			this.Log = log;
			this.Length = Names.Values.Select(v => v.Length).Max();
		}

		public override string ToString() => $"{Names[Log.Type].PadLeft(Length)} | {Log.Time:dd.MM.yyyy hh:mm.ss.fff}";
	}
}
