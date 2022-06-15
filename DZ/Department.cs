using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Department
    {
        public Department()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; } = null!;
        public int FacultyId { get; set; }
        public int HeadId { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
        public virtual Head Head { get; set; } = null!;
        public virtual ICollection<Group> Groups { get; set; }
    }
}
