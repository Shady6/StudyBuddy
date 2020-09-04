using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class Cohort
	{
		[Key]
		public int Id { get; set; }
		List<Course> Courses { get; set; }
		List<Group> Groups { get; set; }
		public List<Assignment> Assignments { get; set; }
		public User Admin { get; set; }
		public List<User> Moderators { get; set; }
		public List<User> Students { get; set; }
		public ClassSchedule? ClassSchedule { get; set; }
	}
}
