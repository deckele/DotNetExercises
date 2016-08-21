using System.Collections.Generic;

namespace Data
{
    public class Chain
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GeoArea> GeoAreas { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}