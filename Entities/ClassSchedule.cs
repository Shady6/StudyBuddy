using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class ClassSchedule
    {
        public int Id { get; set; }

        public int CohortId { get; set; }
        public int GroupId { get; set; }

        public virtual Cohort Cohort { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
