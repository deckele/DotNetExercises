using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Price
    {
        [Key()]
        public long StoreID { get; set; }
        [Key()]
        public long ItemID {get; set;}
        public double ItemPrice { get; set; }

        public virtual Item Item { get; set; }
    }
}