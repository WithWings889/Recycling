using System;
using System.Collections.Generic;

namespace Lab1ISTP
{
    public partial class MaterialGarbageType
    {
        public int Id { get; set; }
        public int IdMaterial { get; set; }
        public int IdGarbageType { get; set; }

        public virtual GarbageType IdGarbageTypeNavigation { get; set; }
        public virtual Material IdMaterialNavigation { get; set; }
    }
}
