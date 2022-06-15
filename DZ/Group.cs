using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Group
    {
        public Group()
        {
            GroupsCurators = new HashSet<GroupsCurator>();
            GroupsLectures = new HashSet<GroupsLecture>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<GroupsCurator> GroupsCurators { get; set; }
        public virtual ICollection<GroupsLecture> GroupsLectures { get; set; }
    }
}
