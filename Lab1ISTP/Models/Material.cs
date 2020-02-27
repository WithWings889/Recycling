using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1ISTP
{
    public partial class Material
    {
        public Material()
        {
            GarbageMaterial = new HashSet<GarbageMaterial>();
            MaterialGarbageType = new HashSet<MaterialGarbageType>();
        }

        public int Id { get; set; }
        [Display(Name = "Маркування матеріалу")]
        public string MaterialCard { get; set; }
        [Display(Name = "Ціна/кілограм")]
        public decimal? PricePerKilogram { get; set; }
        [Display(Name = "Інформація")]
        public string Info { get; set; }

        public virtual ICollection<GarbageMaterial> GarbageMaterial { get; set; }
        public virtual ICollection<MaterialGarbageType> MaterialGarbageType { get; set; }
    }
}
