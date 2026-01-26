using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Factory
	{
		public static Human Create(string type)
		{
			Human human = null;
			switch (type)
			{
				case "Human":				human = new Human("", "", 0);						break;
				case nameof(AcademyMember):	human = new AcademyMember("", "", 0, "");			break;
				case nameof(Student):		human = new Student("", "", 0, "", "", 0, 0);		break;
				case nameof(Graduate):		human = new Graduate("", "", 0, "", "", 0, 0, "");	break;
				case nameof(Specialist):	human = new Specialist("", "", 0, "", "", 0, 0, "",0);break;
				case nameof(Teacher):		human = new Teacher("", "", 0, "", 0);				break;
			}
			return human;
		}
	}
}
