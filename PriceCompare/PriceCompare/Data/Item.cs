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

        public virtual ICollection<GeoArea> GeoAreas { get; set; }
        public virtual ICollection<Chain> Chains { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}