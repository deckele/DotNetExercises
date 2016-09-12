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
        public ObservableCollection<Cart> GetValidCarts(ObservableCollection<ItemInQuantity> chosenItemsInQty, List<Store> stores)
        {
            //Output container:
            var validCarts = new ObservableCollection<Cart>();

            foreach (var store in stores)
            {
                //Are all chosen items found in cart?
                bool cartOk = true;
                var cartToCompare = new CartToCompare(store);

                foreach (var chosenItemInQty in chosenItemsInQty)
                {
                    //Does our store have a price for this xhosen item?
                    bool foundStore = false;

                    //Check the prices list for the item:
                    foreach (var price in chosenItemInQty.Item.Prices)
                    {
                        //If there's a price that matches our store:
                        if (price.Store.Equals(store))
                        {
                            //Mark the chosen item was found
                            foundStore = true;
                            //Add the item to the cart multiplied by chosen quantity:
                            cartToCompare.CartTotalPrice += (price.ItemPrice * chosenItemInQty.ItemQuantity);
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
                    var sortedCartPricesList = cartToCompare.CartPrices.OrderBy(p => p.ItemPrice);
                    var sortedCartPrices = new ObservableCollection<Price>();
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

                        HighestPriceItem = sortedCartPrices.Count > 0 ? sortedCartPrices.Last() : null,
                        SecondHighestPriceItem = sortedCartPrices.Count > 1 ? sortedCartPrices[sortedCartPrices.Count - 2] : null,
                        ThirdHighestPriceItem = sortedCartPrices.Count > 2 ? sortedCartPrices[sortedCartPrices.Count - 3] : null,
                        LowestPriceItem = sortedCartPrices.Count > 0 ? sortedCartPrices[0] : null,
                        SecondLowestPriceItem = sortedCartPrices.Count > 1 ? sortedCartPrices[1] : null,
                        ThirdLowestPriceItem = sortedCartPrices.Count > 2 ? sortedCartPrices[2] : null,
                    };
                    validCarts.Add(cart);
                }
            }
            return validCarts;
        }
    }
}
