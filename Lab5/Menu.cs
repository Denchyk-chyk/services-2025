namespace Lab5
{
	/// <summary>
	/// Клас для реалізації консольного інтерфейсу застосунку
	/// </summary>
	internal static class Menu
	{
		/// <summary>
		/// Метод для завантаження даних для студента
		/// </summary>
		public static void Load()
		{
			Console.WriteLine("Select path to student data");
			bool close;

			using (var editor = new StudentEditor(Console.ReadLine().Trim('"')))
			{
				Use(editor, out close);
			}

			if (!close)
			{
				Load();
			}
		}

		/// <summary>
		/// Метод для роботи з даними про студента
		/// </summary>
		/// <param name="editor">Екземпляр класу для роботи з даними про студента збережених у певному файлі</param>
		/// <param name="close">Повертає true якщо користувач вирішив закрити програму</param>
		private static void Use(StudentEditor editor, out bool close)
		{
			Console.WriteLine(
					"Edit student data (name of property)\n" +
					"Save and close current (save)\n" +
					"Close the application (close)");

			string data = Console.ReadLine();

			if (data == "save")
			{
				close = false;
			}
			else if (data == "close")
			{
				close = true;
			}
			else 
			{
				try
				{
					Console.WriteLine("Input value");
					editor.Edit(data, Console.ReadLine());
				}
				catch (Exception e)
				{
					Console.WriteLine($"Wrong data. {e.Message}");
				}

				Use(editor, out close);
			}
		}
	}
}
