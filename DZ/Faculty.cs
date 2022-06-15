using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Faculty
    {
        public Faculty()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public int Building { get; set; }
        public string Name { get; set; } = null!;
        public int DeanId { get; set; }

        public virtual Dean Dean { get; set; } = null!;
        public virtual ICollection<Department> Departments { get; set; }
    }
}
