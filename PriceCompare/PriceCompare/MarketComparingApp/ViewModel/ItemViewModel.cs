using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace MarketComparingApp.ViewModel
{
    public class ItemViewModel : ObservableObject
    {
        public ItemViewModel()
        {
            ItemQuantity = 0;
        }

        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
    }
}
