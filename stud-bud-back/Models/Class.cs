using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class Class
	{
		public Course Course { get; set; }
		public Time StartTime { get; set; }
		public Time EndTime { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
	}
}
