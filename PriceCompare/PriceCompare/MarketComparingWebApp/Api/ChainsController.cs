using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using Data;

namespace MarketComparingWebApp.Api
{
    [RoutePrefix("api/chains")]
    public class ChainsController : ApiController
    {
        //public ChainsController()
        //{
        //    var context = new MarketContext();
        //    Chains = context.Chains
        //        .Include(c => c.Stores
        //        .Select(s => s.Prices
        //        .Select(p => p.Item.Prices))).ToList();
        //}

        //public List<Chain> Chains { get; set; }

        // GET: api/Chains
        [Route("getChains")]
        [HttpGet]
        public IHttpActionResult GetChains()
        {
            var context = new MarketContext();
            var chains = context.Chains.Select(c => new
            {
                name = c.Name,
                chainId = c.ChainID,
                stores = c.Stores.Select(s => new
                {
                    storeId = s.StoreID,
                    name = s.Name,
                    adress = s.Address,
                    city = s.City,
                    prices = s.Prices.Where(p => p.Item.Prices.Count > 8).Select(p => new
                    //Prices = s.Prices.Where(p => p.Item.Prices.Count > 8).Select(p => new
                    {
                        productPrice = p.ItemPrice,
                        product = new
                        {
                            name = p.Item.Name,
                            id = p.ItemID,
                            units = p.Item.Units,
                            unitsQuantity = p.Item.UnitsQuantity,
                            selectedQuantity = 1
                        }
                    })
                })
            });
            return Json(chains);
        }
    }
}