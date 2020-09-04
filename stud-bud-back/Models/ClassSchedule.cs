using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class ClassSchedule
	{
		public int Id { get; set; }
		List<Class> Classes { get; set; }
	}
}
