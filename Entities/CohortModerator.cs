using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class CohortModerator
    {
        public int UserId { get; set; }
        public int CohortId { get; set; }

        public virtual Cohort Cohort { get; set; }
        public virtual User User { get; set; }
    }
}
