using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Academy
{
	class Streamer
	{
		const string delimiter = "\n------------------------------------\n";
		public static void Print(Human[] group)
		{
			Console.WriteLine(delimiter);
			//2) Virtual methods;
			//Позволяют уточнить информацию о объекте без выполнения Downcast
			//virtual	override
			for (int i = 0; i < group.Length; i++)
			{
				//group[i].Info();
				Console.WriteLine(group[i]);
			}
			Console.WriteLine(delimiter);

			//object.ToString();
		}
		public static void Save(Human[] group, string filename)
		{
			Directory.SetCurrentDirectory("..\\..");
			/*
				.  - ссылка на текущий каталог;
				.. - ссылка на родительский каталог;
			 */
			Console.WriteLine(Directory.GetCurrentDirectory());

			//1) Создаем поток:
			//string filename = "P_421.txt";
			StreamWriter writer = new StreamWriter(filename);//Поток автоматически открывается при создании

			//2) Выполняем запись в поток:
			for (int i = 0; i < group.Length; i++)
			{
				//Сериализация объекта - помещение всех свойств объекта в один поток данных, в нашем случае в строку.
				writer.WriteLine(group[i].ToFileString() + ";");    //Все что записывается в поток, попадает в фай этого потока
			}

			//3) Потоки обязательно нужно закрывать:
			writer.Close();

			Process.Start("notepad", filename);
		}
		public static Human[] Load(string filename)
		{
			List<Human> group = new List<Human>();
			//Exceptions
			//try ... catch ...
			try
			{
				//Потенциально опасный код - код, в котором может возникнуть исключительная ситуация:
				Directory.SetCurrentDirectory("..\\..");
				Console.WriteLine(Directory.GetCurrentDirectory());
				StreamReader reader = new StreamReader(filename);
				//Factory factory = new Factory();
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					//Console.WriteLine(line);
					String[] values = line.Split(":,;".ToCharArray());
					//for (int i = 0; i < values.Length; i++) Console.Write($"{values[i]}\t");Console.WriteLine();
					//Десериализация - превращение сплошного потока данных, например строки в объект.
					//Factory - это порождающий паттерн проектирования, который создает требуемый объект, и возвращает его.
					group.Add(Factory.Create(values[0]).Init(values));
				}
				reader.Close();
				throw new Exception("Бросаем исключение");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return group.ToArray();
		}
	}
}
