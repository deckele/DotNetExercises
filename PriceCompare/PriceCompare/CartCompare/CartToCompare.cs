using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data;

namespace CartCompare
{
    internal class CartToCompare
    {
        public CartToCompare(Store store)
        {
            CartTotalPrice = 0.0;
            Store = store;
            CartPrices = new List<Price>();
        }

        public double CartTotalPrice { get; set; }
        public Store Store { get; }
        public List<Price> CartPrices { get; set; }
    }
}