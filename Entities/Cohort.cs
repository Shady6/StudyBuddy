using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class Cohort
    {
        public Cohort()
        {
            CohortModerator = new HashSet<CohortModerator>();
            CohortStudent = new HashSet<CohortStudent>();
            Course = new HashSet<Course>();
            Group = new HashSet<Group>();
        }

        public int Id { get; set; }
        public int? AdminId { get; set; }
        public int ClassScheduleId { get; set; }
        public string Name { get; set; }

        public virtual User Admin { get; set; }
        public virtual ClassSchedule ClassSchedule { get; set; }
        public virtual ICollection<CohortModerator> CohortModerator { get; set; }
        public virtual ICollection<CohortStudent> CohortStudent { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Group> Group { get; set; }
    }
}
