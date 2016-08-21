using System.Collections.Generic;

namespace Data
{
    public class GeoArea
    {
        public int ID { get; set; }
        public string AreaAdress { get; set; }

        public virtual ICollection<Chain> Chains { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}