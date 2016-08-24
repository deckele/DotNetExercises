using System.Collections;
using System.Collections.Generic;

namespace Data
{
    public class Price
    {
        public long ItemCode {get; set;}
        public double ItemPrice { get; set; }

        public virtual ICollection<Item> Items
    }
}