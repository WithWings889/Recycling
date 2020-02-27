using System;
using System.Collections.Generic;

namespace Lab1ISTP
{
    public partial class GarbageTypeFactory
    {
        public int Id { get; set; }
        public int IdGarbageType { get; set; }
        public int IdFactory { get; set; }

        public virtual GarbageFactory IdFactoryNavigation { get; set; }
        public virtual GarbageType IdGarbageTypeNavigation { get; set; }
    }
}
