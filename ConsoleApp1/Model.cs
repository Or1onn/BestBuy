using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum GameStyle
    {
        RPG = 0,
        MMMO,
        SandBox,
        Shooter
    }

    public class Model
    {
        public Model()
        {
            Style = GameStyle.RPG;
            ReleaseDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        [Required]
        public string? GameName { get; set; }
        [Required]
        public int MyProperty { get; set; }


        public GameStyle Style { get; set; }
        public DateTime ReleaseDate { get; set; }
        Company? Company { get; set; }
    }

}
