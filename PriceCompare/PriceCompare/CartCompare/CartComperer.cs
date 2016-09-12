using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace CartCompare
{
    public class CartComperer
    {
        ////Output container:
        //public ObservableCollection<Cart> ValidCarts { get; set; }

        //public CartComperer(ObservableCollection<Item> chosenItems, List<Store> stores)
        //{
        //    ValidCarts = new ObservableCollection<Cart>();
        //    GetValidCarts(chosenItems, stores);
        //}

        //Check which stores can supply our shopping list:
        public ObservableCollection<Cart> GetValidCarts(ObservableCollection<Item> chosenItems, List<Store> stores)
        {
            //Output container:
            var validCarts = new ObservableCollection<Cart>();

            foreach (var store in stores)
            {
                //Are all chosen items found in cart?
                bool cartOk = true;
                var cartToCompare = new CartToCompare(store);

                foreach (var chosenItem in chosenItems)
                {
                    //Does our store have a price for this xhosen item?
                    bool foundStore = false;

                    //Check the prices list for the item:
                    foreach (var price in chosenItem.Prices)
                    {
                        //If there's a price that matches our store:
                        if (price.Store.Equals(store))
                        {
                            //Mark the chosen item was found
                            foundStore = true;
                            //Add the item to the cart:
                            cartToCompare.CartTotalPrice += price.ItemPrice;
                            //No need to look for another price:
                            break;
                        }
                    }
                    //If we couldn't find a price for this item:
                    if (!foundStore)
                    {
                        //This cart is invalid:
                        cartOk = false;
                        //No need to look for other items:
                        break;
                    }
                }
                //If we found all the selected items:
                if (cartOk)
                {
                    
                    //Sort the cart items by their cost for the three highest and lowest prices:
                    var sortedCartPricesList = cartToCompare.CartPrices.Select(p => p.ItemPrice).ToList();
                    sortedCartPricesList.Sort();
                    var sortedCartPrices = new ObservableCollection<double>();
                    foreach (var sortedPrice in sortedCartPricesList)
                    {
                        sortedCartPrices.Add(sortedPrice);
                    }

                    //Create validated cart object: 
                    var cart = new Cart()
                    {
                        CartTotalPrice = cartToCompare.CartTotalPrice,
                        CartPrices = sortedCartPrices,

                        ChainName = cartToCompare.Store.Chain.Name,
                        StoreName = cartToCompare.Store.Name,
                        Adress = cartToCompare.Store.Address,
                        City = cartToCompare.Store.City,

                        HighestPriceItem = sortedCartPrices.Count > 0 ? (double?)sortedCartPrices.Last() : null,
                        SecondHighestPriceItem = sortedCartPrices.Count > 1 ? (double?)sortedCartPrices[sortedCartPrices.Count-2] : null,
                        ThirdHighestPriceItem = sortedCartPrices.Count > 2 ? (double?)sortedCartPrices[sortedCartPrices.Count - 3] : null,
                        LowestPriceItem = sortedCartPrices.Count > 0 ? (double?)sortedCartPrices[0] : null,
                        SecondLowestPriceItem = sortedCartPrices.Count > 1 ? (double?)sortedCartPrices[1] : null,
                        ThirdLowestPriceItem = sortedCartPrices.Count > 2 ? (double?)sortedCartPrices[2] : null,
                    };
                    validCarts.Add(cart);
                }
            }
            return validCarts;
        }
    }
}
