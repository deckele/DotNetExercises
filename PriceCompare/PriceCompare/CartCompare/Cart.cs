using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double HighestPriceItem { get; set; }
        public double SecondHighestPriceItem { get; set; }
        public double ThirdHighestPriceItem { get; set; }
        public double LowestPriceItem { get; set; }
        public double SecondLowestPriceItem { get; set; }
        public double ThirdLowestPriceItem { get; set; }


    }
}
