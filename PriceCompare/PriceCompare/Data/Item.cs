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
        public long? InnerBarcode { get; set; }   //If item barcode has less than 9 digits, it was generated in the store or chain levels.
                                                  //Thus, items can't be compared if they have only inner barcodes.
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