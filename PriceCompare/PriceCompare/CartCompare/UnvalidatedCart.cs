using System.Collections.Generic;
using Data;

namespace CartCompare
{
    internal class UnvalidatedCart
    {
        public UnvalidatedCart(Store store)
        {
            CartTotalPrice = 0.0;
            Store = store;
        }

        public double CartTotalPrice { get; set; }
        private Store Store { get; }
    }
}