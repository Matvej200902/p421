using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Teacher:AcademyMember
	{
		public int Experience { get; set; }
		public Teacher
			(
			string lastName, string firstName, int age,
			string speciality,
			int experience
			):base(lastName, firstName, age, speciality)
		{
			Experience = experience;
			Console.WriteLine($"TConstructor:{GetHashCode()}");
		}
		~Teacher()
		{
			Console.WriteLine($"TDestructor:{GetHashCode()}");
		}
		public override Human Init(string[] values)
		{
			base.Init(values);
			Experience = Convert.ToInt32(values[5]);
			return this;
		}
		public override void Info()
		{
			base.Info();
			Console.WriteLine(Experience);
		}
		public override string ToString()
		{
			return base.ToString() + Experience.ToString().PadRight(5);
		}
		public override string ToFileString()
		{
			return base.ToFileString()+$",{Experience}";
		}
	}
}
