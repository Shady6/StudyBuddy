using stud_bud_back.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Models.Cohort
{
	public class CohortCreationModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public bool IsStudentInCohort { get; set; }
	}
}
