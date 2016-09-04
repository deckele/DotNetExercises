
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Store
    {
        [Key]
        public int StorePK { get; set; }
        public long StoreID { get; set; }
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