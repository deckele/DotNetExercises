using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace CartCompare
{
    public class CartValidator
    {
        //Output container:
        public ObservableCollection<Cart> _validCarts;

        public CartValidator(ObservableCollection<Item> chosenItems)
        {
            _validCarts = new ObservableCollection<Cart>();

            using (var context = new MarketContext())
            {
                GetValidCarts(context, chosenItems.ToList());
            }
        }

        //Check which stores can supply our shopping list:
        private void GetValidCarts(MarketContext context, List<Item> chosenItems)
        {
            foreach (var store in context.Stores)
            {
                //Are all items found?
                bool CartOK = true;

                var cart = new UnvalidatedCart(store);


            }
        }
    }
}
