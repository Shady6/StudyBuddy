using System;
using System.Collections.Generic;

namespace stud_bud_back.Entities
{
    public partial class Lesson
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ClassScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DayOfWeek { get; set; }
        public virtual Course Course { get; set; }
        public virtual ClassSchedule ClassSchedule { get; set; }
    }
}
