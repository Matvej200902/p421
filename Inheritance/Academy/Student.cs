using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Student:AcademyMember
	{
		public string Group { get; set; }
		public double Rating { get; set; }		//Успеваемость
		public double Attendance { get; set; }  //Посещаемость
		public Student
			(
			string lastName, string firstName, int age,
			string speciality,
			string group, double rating, double attendance
			):base(lastName, firstName, age, speciality)
		{
			Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"SConstructor:\t{GetHashCode()}");
		}

		public Student
			(
			AcademyMember academyMember, 
			string group, double rating, double attendance
			):base(academyMember)
		{
			Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"SCostructor");
		}
		public Student(Student other) : base(other)
		{
			this.Group = other.Group;
			this.Rating = other.Rating;
			this.Attendance = other.Attendance;
			Console.WriteLine($"SCopyConstructor:\t{this}");
		}
		~Student()
		{
			Console.WriteLine($"SDestructor:\t{GetHashCode()}");
		}
		public override Human Init(string[] values)
		{
			base.Init(values);
			Group = values[5];
			Rating = Convert.ToDouble(values[6]);
			Attendance = Convert.ToDouble(values[7]);
			return this;
		}
		public override void Info()
		{
			base.Info();
			Console.WriteLine($"{Group} {Rating} {Attendance}");
		}
		public override string ToString()
		{
			return base.ToString() + $"{Group.PadRight(8)} {Rating.ToString().PadRight(5)} {Attendance.ToString().PadRight(5)}";
		}
		public override string ToFileString()
		{
			return base.ToFileString()+$",{Group},{Rating},{Attendance}";
		}
	}
}
