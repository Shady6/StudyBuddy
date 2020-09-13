using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class Course
    {
        public Course()
        {
            Assignment = new HashSet<Assignment>();
            //GroupAssignment = new HashSet<GroupAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AdjunctName { get; set; }
        public int? CohortId { get; set; }

        public virtual Cohort Cohort { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; }
        //public virtual ICollection<GroupAssignment> GroupAssignment { get; set; }
    }
}
