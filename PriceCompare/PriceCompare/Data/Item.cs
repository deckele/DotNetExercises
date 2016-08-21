using System.Collections.Generic;

namespace Data
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Units { get; set; }
        public int QuantityInPackage { get; set; }

        public ICollection<GeoArea> GeoAreas { get; set; }
        public ICollection<Chain> Chains { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}