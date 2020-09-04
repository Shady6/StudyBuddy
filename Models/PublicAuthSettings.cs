using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models
{
	public class PublicAuthSettings
	{
		public string Domain { get; set; }
		public string ClientId { get; set; }
		public string Audience { get; set; }
	}
}
