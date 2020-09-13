using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class User
    {
        public User()
        {
            CohortModerator = new HashSet<CohortModerator>();
            CohortStudent = new HashSet<CohortStudent>();
            Cohorts = new HashSet<Cohort>();
            GroupUser = new HashSet<GroupUser>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<CohortModerator> CohortModerator { get; set; }
        public virtual ICollection<CohortStudent> CohortStudent { get; set; }
        public virtual ICollection<Cohort> Cohorts { get; set; }
        public virtual ICollection<GroupUser> GroupUser { get; set; }
    }
}
