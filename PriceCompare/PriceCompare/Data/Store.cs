
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Store
    {
        [Key, Column(Order = 1)]
        public long StoreID { get; set; }
        [Key, Column(Order= 0), ForeignKey("Chain")]
        public long ChainID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Chain Chain { get; set; }
        public virtual ICollection<Price> Prices { get; set; }

        public Store()
        {
            Prices = new HashSet<Price>();
        }
    }
}