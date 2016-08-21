using System.Collections.Generic;

namespace Data
{
    public class Chain
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<GeoArea> GeoAreas { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}