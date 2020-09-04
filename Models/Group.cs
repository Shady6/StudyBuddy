using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class Group
	{
		[Key]
		public int Id { get; set; }
		public List<User> Students { get; set; }
		public List<Assignment> Assignments{ get; set; }
		public ClassSchedule ClassSchedule { get; set; }
	}
}
