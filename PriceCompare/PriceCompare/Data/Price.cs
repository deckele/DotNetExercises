using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Price
    {
        [Key, Column(Order = 0), ForeignKey("Item")]
        public long ItemID { get; set; }
        [Key, Column(Order = 1), ForeignKey("Store")]
        public long ChainID { get; set; }
        [Key, Column(Order = 2), ForeignKey("Store")]
        public long StoreID { get; set; }
        public double ItemPrice { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }

        //Prices are compared on the basis of three parameters: ItemsID, PriceID and ChainID:
        public override bool Equals(object obj)
        {
            var otherPrice = obj as Price;
            if (otherPrice == null)
                return false;
            if (ItemID == otherPrice.ItemID)
            {
                if (StoreID == otherPrice.StoreID)
                {
                    return (ChainID == otherPrice.ChainID);
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (int)(ItemID);
        }
    }
}