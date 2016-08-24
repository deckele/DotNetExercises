using System;
using System.Collections.Generic;

namespace Data
{
    public class Item
    {
        public long ItemID { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public int QuantityInPackage { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
    }
}