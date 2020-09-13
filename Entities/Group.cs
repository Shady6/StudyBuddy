using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
	public partial class Group
	{
		public Group()
		{
			//GroupAssignment = new HashSet<GroupAssignment>();
			Assignments = new HashSet<Assignment>();
			GroupUser = new HashSet<GroupUser>();
		}

		public int Id { get; set; }
		public int? CohortId { get; set; }
		public int GroupNumber { get; set; }

		public virtual ClassSchedule ClassSchedule { get; set; }
		public virtual Cohort Cohort { get; set; }
		//public virtual ICollection<GroupAssignment> GroupAssignment { get; set; }
		public virtual ICollection<Assignment> Assignments { get; set; }
		public virtual ICollection<GroupUser> GroupUser { get; set; }
	}
}
