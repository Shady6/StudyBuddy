using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email{ get; set; }
		//public List<Role> Roles { get; set; }
	}
}
