using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class GroupUser
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual User Student { get; set; }
    }
}
