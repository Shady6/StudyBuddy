using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int? GroupId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
    }
}
