using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Data;

namespace MarketComparingWebApp.Api
{
    [RoutePrefix("api/stores")]
    public class StoresController : ApiController
    {
        public StoresController()
        {
            var dataService = new DataManager(8);
            Stores = dataService.Stores;
        }

        public List<Store> Stores { get; set; }

        // GET: api/Stores
        [Route("getStores")]
        [HttpGet]
        public IHttpActionResult GetStores()
        {
            var stores = Stores.Select(s => new
            {
                ChainName = s.Chain.Name,
                s.ChainID,
                s.StoreID,
                s.Name,
                s.Address,
                s.City
            });
            return Json(stores);
        }
    }
}