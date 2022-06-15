using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class LectureRoom
    {
        public LectureRoom()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
