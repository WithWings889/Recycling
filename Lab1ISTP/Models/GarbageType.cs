using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1ISTP
{
    public partial class GarbageType
    {
        public GarbageType()
        {
            GarbageTypeFactory = new HashSet<GarbageTypeFactory>();
            MaterialGarbageType = new HashSet<MaterialGarbageType>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }

        public virtual ICollection<GarbageTypeFactory> GarbageTypeFactory { get; set; }
        public virtual ICollection<MaterialGarbageType> MaterialGarbageType { get; set; }
    }
}
