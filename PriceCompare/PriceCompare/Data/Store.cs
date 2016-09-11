
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Store
    {
        [Key, Column(Order = 0), ForeignKey("Chain")]
        public long ChainID { get; set; }
        [Key, Column(Order = 1)]
        public long StoreID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime UpdateDate { get; set; }

        public Chain Chain { get; set; }
        public ICollection<Price> Prices { get; set; }

        public Store()
        {
            Prices = new HashSet<Price>();
        }

        public override bool Equals(object obj)
        {
            var otherStore = obj as Store;
            if (otherStore == null)
                return false;
            if (StoreID == otherStore.StoreID)
                return (ChainID == otherStore.ChainID);
            return false;
        }
        public override int GetHashCode()
        {
            return (int)StoreID ^ (int)ChainID;
        }
    }
}