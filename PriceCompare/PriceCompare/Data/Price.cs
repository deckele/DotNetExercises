using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Price
    {
        [Column(Order = 0), Key, ForeignKey("Store")]
        public long StoreID { get; set; }
        [Column(Order = 1), Key, ForeignKey("Item")]
        public long ItemID {get; set;}
        public double ItemPrice { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
    }
}