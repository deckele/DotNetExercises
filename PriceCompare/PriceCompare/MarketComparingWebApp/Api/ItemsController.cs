using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.ModelBinding;
using Data;

namespace MarketComparingWebApp.Api
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        //private MarketContext db = new MarketContext();

        public ItemsController()
        {
            var dataService = new DataManager(8);
            Items = dataService.Items;
        }

        public List<Item> Items { get; set; }

        // GET: api/Items
        [Route("getItems")]
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            //db.Items.Include(i => i.Prices)
            var items = Items.Select(i => new
            {
                Prices = i.Prices.Select(p => new
                {
                    p.StoreID,
                    p.ItemID,
                    p.ChainID
                }),
                i.ItemID,
                i.Name
            });
            return Json(items);
        }

        //// GET: api/Items/5
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult GetItem(long id)
        //{
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}

        //// PUT: api/Items/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutItem(long id, Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != item.ItemID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(item).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Items
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult PostItem(Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Items.Add(item);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ItemExists(item.ItemID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = item.ItemID }, item);
        //}

        //// DELETE: api/Items/5
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult DeleteItem(long id)
        //{
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Items.Remove(item);
        //    db.SaveChanges();

        //    return Ok(item);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ItemExists(long id)
        //{
        //    return db.Items.Count(e => e.ItemID == id) > 0;
        //}
    }
}