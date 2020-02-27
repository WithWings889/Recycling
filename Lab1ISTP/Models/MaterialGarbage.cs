using System;
using System.Collections.Generic;

namespace Lab1ISTP
{
    public partial class MaterialGarbage
    {
        public MaterialGarbage()
        {
            InverseIdMaterialNavigation = new HashSet<MaterialGarbage>();
        }

        public int Id { get; set; }
        public int? KilogramOfMaterial { get; set; }
        public int IdMaterial { get; set; }
        public int IdGarbage { get; set; }

        public virtual Garbage IdGarbageNavigation { get; set; }
        public virtual MaterialGarbage IdMaterialNavigation { get; set; }
        public virtual ICollection<MaterialGarbage> InverseIdMaterialNavigation { get; set; }
    }
}
