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
                c.Name,
                c.ChainID,
                Stores = c.Stores.Select(s => new
                {
                    s.StoreID,
                    s.Name,
                    s.Address,
                    s.City,
                    Prices = s.Prices.Select(p => new
                    //Prices = s.Prices.Where(p => p.Item.Prices.Count > 8).Select(p => new
                    {
                        p.ItemPrice,
                        Item = new
                        {
                            p.Item.Name,
                            p.ItemID,
                        }
                    })
                })
            });
            return Json(chains);
        }
    }
}