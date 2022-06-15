using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Teacher
    {
        public Teacher()
        {
            Assistants = new HashSet<Assistant>();
            Curators = new HashSet<Curator>();
            Deans = new HashSet<Dean>();
            Heads = new HashSet<Head>();
            Lectures = new HashSet<Lecture>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public virtual ICollection<Assistant> Assistants { get; set; }
        public virtual ICollection<Curator> Curators { get; set; }
        public virtual ICollection<Dean> Deans { get; set; }
        public virtual ICollection<Head> Heads { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
