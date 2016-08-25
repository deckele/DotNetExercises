using System;
using System.IO;
using System.Xml.Linq;
using MarketDataXmlParser;

namespace Data
{
    public class MarketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MarketContext>
    {
        protected override void Seed(MarketContext context)
        {
            var filePath = string.Format(@"D:\Program Files\GO\GoProjects\bin\PriceFull7290725900003_001_201608140516.xml");
            var doc = XDocument.Load(filePath);

            foreach (var itemElement in doc.Descendants("Item"))
            {
                var item = new Item();

                var itemId = itemElement.Element("ItemCode");
                if (itemId != null)
                    item.ItemID = long.Parse(itemId.Value);
                else item.ItemID = -1;

                item.Name = itemElement.Element("ItemName")?.Value;

                var itemQty = itemElement.Element("QtyInPackage");
                if (itemQty != null)
                    item.QuantityInPackage = int.Parse(itemQty.Value);
                else item.QuantityInPackage = -1;

                item.Units = itemElement.Element("UnitOfMeasure")?.Value;

                context.Items.Add(item);

                var price = new Price();

                var itemPrice = itemElement.Element("ItemPrice");
                if (itemPrice != null)
                    price.ItemPrice = double.Parse(itemPrice.Value);

                var itemUpdateDate = itemElement.Element("PriceUpdateDate");
                if (itemUpdateDate != null)
                    price.UpdateDate = DateTime.Parse(itemUpdateDate.Value);

                context.Prices.Add(price);
            }

            filePath = string.Format(@"D:\Program Files\GO\GoProjects\bin\Stores7290725900003_201608160753");
            doc = XDocument.Load(filePath);

            var chain = new Chain();
            var chainId = doc.Element("ChainId");
            if (chainId != null)
                chain.ChainID = long.Parse(chainId.Value);
            chain.Name = doc.Element("Store")?.Element("ChainName")?.Value;

            context.Chains.Add(chain);

            foreach (var storeElement in doc.Descendants("Store"))
            {
                var store = new Store();

                var storeId = storeElement.Element("StoreID");
                if (storeId != null)
                    store.StoreID = long.Parse(storeId.Value);

                store.Adress = storeElement.Element("Address")?.Value + " , " + storeElement.Element("City")?.Value;

                store.Name = storeElement.Element("StoreName")?.Value;

                context.Stores.Add(store);
            }
            context.SaveChanges();
        }
    }
}