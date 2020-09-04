using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class Course
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string AdjunctName { get; set; }
	}
}
