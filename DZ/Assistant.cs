using System;
using System.Collections.Generic;

namespace EFCore_HomeWork_1
{
    public partial class Assistant
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; } = null!;
    }
}
