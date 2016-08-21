
using System.Collections.Generic;

namespace Data
{
    public class Store
    {
        public int ID { get; set; }
        public string Adress { get; set; }

        public virtual GeoArea GeoArea { get; set; }
        public virtual Chain Chain { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}