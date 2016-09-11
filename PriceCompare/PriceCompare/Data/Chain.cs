using System.Collections.Generic;

namespace Data
{
    public class Chain
    {
        public long ChainID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public Chain()
        {
            Stores = new HashSet<Store>();
        }

        public override bool Equals(object obj)
        {
            var otherChain = obj as Chain;
            if (otherChain == null)
                return false;
            return (ChainID == otherChain.ChainID);
        }
        public override int GetHashCode()
        {
            return (int)ChainID;
        }
    }
}