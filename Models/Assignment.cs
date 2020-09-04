using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class Assignment
	{
		[Key]
		public int Id { get; set; }
		public Course Course{ get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
	}
}
