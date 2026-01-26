using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBaseClass
{
	class Car:OnRoad
	{
		public override void Move()
		{
			Console.WriteLine("Ездит на четырех колесах");
		}
	}
}
