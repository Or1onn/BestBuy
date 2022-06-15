using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int Class { get; set; }
        public int DayOfWeek { get; set; }
        public int Week { get; set; }
        public int LectureId { get; set; }
        public int LectureRoomId { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual LectureRoom LectureRoom { get; set; } = null!;
    }
}
