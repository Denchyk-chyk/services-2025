namespace Lab2
{
	internal struct Log(Operation type, DateTime time)
	{
		public DateTime Time { get; } = time;
		public Operation Type { get; } = type;
	}

	internal enum Operation
	{
		Load, Generate, Save
	}
}
