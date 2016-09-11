using System;
using System.Collections.Generic;

namespace Data
{
    public class Item
    {
        public long ItemID { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public string UnitsQuantity { get; set; }
        public string QuantityInPackage { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

        public Item()
        {
            Prices = new HashSet<Price>();
        }

        public override bool Equals(object obj)
        {
            var otherItem = obj as Item;
            if (otherItem == null)
                return false;
            return (ItemID == otherItem.ItemID);
        }
        public override int GetHashCode()
        {
            return (int)ItemID;
        }
    }
}