using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBaseClass
{
	class Bike:OnRoad
	{
		public override void Move()
		{
			Console.WriteLine("Ездит на двух колесах, может перевозить не более трех человек");
		}
	}
}
