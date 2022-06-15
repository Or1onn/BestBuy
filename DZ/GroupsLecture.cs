using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class GroupsLecture
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LectureId { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Lecture Lecture { get; set; } = null!;
    }
}
