
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Store
    {
        public long StoreID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string GeoArea { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("Chain")]
        public long ChainID { get; set; }

        public virtual Chain Chain { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}