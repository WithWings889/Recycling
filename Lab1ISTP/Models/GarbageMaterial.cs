using System;
using System.Collections.Generic;

namespace Lab1ISTP
{
    public partial class GarbageMaterial
    {
        public int Id { get; set; }
        public int KilogramOfMaterial { get; set; }
        public int IdMaterial { get; set; }
        public int IdGarbage { get; set; }

        public virtual Garbage IdGarbageNavigation { get; set; }
        public virtual Material IdMaterialNavigation { get; set; }
    }
}
