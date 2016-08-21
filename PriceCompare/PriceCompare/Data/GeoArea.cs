using System.Collections.Generic;

namespace Data
{
    public class GeoArea
    {
        public int ID { get; set; }
        public string AreaAdress { get; set; }

        public ICollection<Chain> Chains { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}