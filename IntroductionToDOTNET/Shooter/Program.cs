using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKey key;
			do
			{
				key = Console.ReadKey(true).Key;    //Ожидает нажатия клавиши и возвращает код нажатой клавиши.
													//Console.WriteLine($"\t{Convert.ToUInt16(key)}\t{key.ToString()}");
				switch (key)
				{
					case ConsoleKey.W: Console.WriteLine("Вперед");	break;
					case ConsoleKey.S: Console.WriteLine("Назад");	break;
					case ConsoleKey.A: Console.WriteLine("Влево");	break;
					case ConsoleKey.D: Console.WriteLine("Вправо");	break;
					case ConsoleKey.Spacebar: Console.WriteLine("Прыжок");	break;
					case ConsoleKey.Enter: Console.WriteLine("Огонь");	break;
					case ConsoleKey.Escape: Console.WriteLine("Выход");	break;
					default: Console.WriteLine("Error:\a"); break;
				}
			} while (key != ConsoleKey.Escape);
		}
	}
}
