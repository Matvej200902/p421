using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBaseClass
{
	class Tramvai:OnRails
	{
		public override void Move()
		{
			Console.WriteLine("Трамвай ездит на рельсах по городу и возит людей");
		}
	}
}
