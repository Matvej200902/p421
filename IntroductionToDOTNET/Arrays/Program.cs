//#define ARRAYS_1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
	class Program
	{
		const string delimiter = "\n---------------------------------------\n";
		static void Main(string[] args)
		{
#if ARRAYS_1
			int[] arr = { 3, 5, 8, 13, 21 };
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + "\t");
			}
			Console.WriteLine();

			Console.Write("Введите размер массива: ");
			int n = Convert.ToInt32(Console.ReadLine());
			arr = new int[n];
			Random rand = new Random(0);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rand.Next(100);
			}
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + "\t");
			}
			Console.WriteLine();
			//Подсчет суммы элементов массива:
			int sum = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				sum += arr[i];
			}
			Console.WriteLine($"Сумма элементов массива: {sum}");
			Console.WriteLine($"Среднее-арифметическое элементов массива: {(double)sum / arr.Length}");
			int min, max;
			min = max = arr[0];
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] < min) min = arr[i];
				if (arr[i] > max) max = arr[i];
			}
			Console.WriteLine($"Минимальное значение в массиве: {min}");
			Console.WriteLine($"Максимальное значение в массиве: {max}");
			Console.WriteLine(delimiter);

			Console.WriteLine($"Сумма элементов массива: {arr.Sum()}");
			Console.WriteLine($"Среднее-арифметическое элементов массива: {arr.Average()}");
			Console.WriteLine($"Минимальное значение в массиве: {arr.Min()}");
			Console.WriteLine($"Максимальное значение в массиве: {arr.Max()}");

			foreach (int i in arr)
			{
				Console.Write(i + "\t");
			}
			Console.WriteLine(); 
#endif
			Random rand = new Random(0);
			Console.Write("Введите количество строк: ");
			int rows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите количество элементов строки: ");
			int cols = Convert.ToInt32(Console.ReadLine());

			int[,] arr = new int[rows, cols];
			Console.WriteLine($"Количество измерений массива: {arr.Rank}");
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					arr[i, j] = rand.Next(100);
				}
			}
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					Console.Write(arr[i, j] + "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			//Сумма элементов массива:
			int sum = 0;
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					sum += arr[i, j];
				}
			}
			Console.WriteLine($"Сумма элементов массива: {sum}");
			Console.WriteLine($"Среднее-арифметическое элементов массива: {(double)sum/arr.Length}");
			Console.WriteLine(delimiter);
			Console.WriteLine($"Сумма элементов массива: {arr.Cast<int>().Sum()}");
			Console.WriteLine($"Среднее-арифметическое:  {arr.Cast<int>().Average()}");
		}
	}
}
