using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace CartCompare
{
    public class Cart
    {
        public Cart()
        {

        }

        public string ChainName { get; set; }
        public string StoreName { get; set; }
        public double CartTotalPrice { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public ObservableCollection<Price> CartPrices { get; set; }
        
        public Price HighestPriceItem { get; set; }
        public Price SecondHighestPriceItem { get; set; }
        public Price ThirdHighestPriceItem { get; set; }
        public Price LowestPriceItem { get; set; }
        public Price SecondLowestPriceItem { get; set; }
        public Price ThirdLowestPriceItem { get; set; }
    }
}
