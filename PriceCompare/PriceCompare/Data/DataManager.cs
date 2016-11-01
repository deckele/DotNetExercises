using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataManager
    {
        private const int DefaultItemComparability = 2;

        public DataManager() : this(DefaultItemComparability)
        {
        }
        public DataManager(int itemComparability)
        {
            using (var context = new MarketContext())
            {
                Stores = context.Stores.Include(s => s.Chain).ToList();
                Items = context.Items.Where(i => i.Prices.Count > itemComparability)
                                     .Include(i => i.Prices.Select(p => p.Item))
                                     .OrderBy(i => i.Name)
                                     .ToList();
                //Chains = context.Chains.ToList()
                //.Include(c => c.Stores
                //.Select(s => s.Prices
                //.Select(p => p.Item.Prices))).ToList();
            }
        }

        public List<Store> Stores { get; }
        public List<Item> Items { get; }
        //public List<Chain> Chains { get; }
    }
}
