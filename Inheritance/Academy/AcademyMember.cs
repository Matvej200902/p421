using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class AcademyMember : Human
	{
		public string Speciality { get; set; }
		public AcademyMember
			(
			string lastName, string firstName, int age,
			string speciality
			) : base(lastName, firstName, age)
		{
			//Конеструктор дочернего класса кроме своих собственных полей
			//так же в обязательном порядке должен принимать поля всех своих родителей
			this.Speciality = speciality;
			Console.WriteLine($"AMConstructor:\t{GetHashCode()}");
		}
		public AcademyMember(Human human, string speciality) : base(human)
		{
			Speciality = speciality;
			Console.WriteLine($"AMConstructor:\t{GetHashCode()}");
		}
		public AcademyMember(AcademyMember other) : base(other)
		{
			this.Speciality = other.Speciality;
			Console.WriteLine($"AMCopyConstructor:\t{GetHashCode()}");
		}
		~AcademyMember()
		{
			Console.WriteLine($"AMDestructor:\t{GetHashCode()}");
		}
		public override Human Init(string[] values)
		{
			base.Init(values);
			Speciality = values[4];
			return this;
		}
		public override void Info()
		{
			base.Info();    //Ключевое слово 'base' охначает непосредственного родителя.
			Console.WriteLine(Speciality);
		}
		public override string ToString()
		{
			return base.ToString() + Speciality.PadRight(12);
		}
		public override string ToFileString()
		{
			return base.ToFileString()+$",{Speciality}";
		}
	}
}
