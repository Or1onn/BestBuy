using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Lecture
    {
        public Lecture()
        {
            GroupsLectures = new HashSet<GroupsLecture>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<GroupsLecture> GroupsLectures { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
