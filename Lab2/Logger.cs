namespace Lab2
{
	internal class Logger
	{
		public List<Log> Logs = new List<Log>();

		/// <summary>
		/// Збереження даних про операцію, виконану користуваем
		/// </summary>
		/// <param name="type"></param>
		public void Log(Operation type)
		{
			Logs.Add(new Log(type, DateTime.Now));
		}
	}
}
