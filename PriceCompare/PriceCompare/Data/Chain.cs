using System.Collections.Generic;

namespace Data
{
    public class Chain
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}