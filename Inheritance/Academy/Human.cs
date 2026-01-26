using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Human
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }
		public Human(string lastName, string firstName, int age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
			Console.WriteLine($"HConstructor:\t{GetHashCode()}");
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			Console.WriteLine($"HCopyConstructor:\t{GetHashCode()}");
		}
		~Human()
		{
			Console.WriteLine($"HDestructor:\t{GetHashCode()}");
		}
		public virtual Human Init(string[] values)
		{
			LastName	= values[1];
			FirstName	= values[2];
			Age			= Convert.ToInt32(values[3]);
			return this;
		}
		public virtual void Info()
		{
			Console.WriteLine($"{LastName} {FirstName} {Age}");
		}
		public override string ToString()
		{
			return $"{base.ToString().Split('.').Last()}:".PadRight(12)  
				+ $"{LastName.PadRight(12)} {FirstName.PadRight(12)} {Age.ToString().PadRight(5)}";
		}
		public virtual string ToFileString()
		{
			return $"{GetType().ToString().Split('.').Last()}:"
				+ $"{LastName},{FirstName},{Age}";
		}
	}
}
