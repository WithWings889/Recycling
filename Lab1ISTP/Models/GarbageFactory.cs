using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1ISTP
{
    public partial class GarbageFactory
    {
        public GarbageFactory()
        {
            GarbageTypeFactory = new HashSet<GarbageTypeFactory>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Адреса")]
        public string Address { get; set; }
        [Display(Name = "Вебсайт")]
        public string Website { get; set; }
        [Display(Name = "Типи сміття")]
        public virtual ICollection<GarbageTypeFactory> GarbageTypeFactory { get; set; }
    }
}
