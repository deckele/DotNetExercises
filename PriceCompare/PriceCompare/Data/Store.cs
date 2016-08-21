
using System.Collections.Generic;

namespace Data
{
    public class Store
    {
        public int ID { get; set; }
        public string Adress { get; set; }

        public GeoArea GeoArea { get; set; }
        public Chain Chain { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}