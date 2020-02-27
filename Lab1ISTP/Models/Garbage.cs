using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1ISTP
{
    public partial class Garbage
    {
        public Garbage()
        {
            GarbageMaterial = new HashSet<GarbageMaterial>();
            MaterialGarbage = new HashSet<MaterialGarbage>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Інформація")]
        public string Info { get; set; }

        public virtual ICollection<GarbageMaterial> GarbageMaterial { get; set; }
        public virtual ICollection<MaterialGarbage> MaterialGarbage { get; set; }
    }
}
