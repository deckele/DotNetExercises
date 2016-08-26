using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class MarketXmlParser
    {
        public void FileExtract(string folderPath)
        {

        }

        public void ParseAllXml(MarketContext context)
        {
            ParseItemsXml(context);
            ParseStoresXml(context);
        }

        public void ParseItemsXml(MarketContext context)
        {
            var filePath = string.Format(@"D:\Program Files\GO\GoProjects\bin\PriceFull7290725900003_001_201608140516.xml");
            var doc = XDocument.Load(filePath);

            foreach (var itemElement in doc.Descendants("Item"))
            {
                var item = new Item();

                var itemId = itemElement.Element("ItemCode");
                if (itemId != null)
                    if(itemId.Value != "")
                        item.ItemID = long.Parse(itemId.Value);

                item.Name = itemElement.Element("ItemName")?.Value;

                var itemQty = itemElement.Element("QtyInPackage");
                if (itemQty != null)
                    if (itemQty.Value != "")
                        item.QuantityInPackage = int.Parse(itemQty.Value);

                item.Units = itemElement.Element("UnitOfMeasure")?.Value;

                context.Items.Add(item);
                context.SaveChanges();

                var price = new Price();

                var itemPrice = itemElement.Element("ItemPrice");
                if (itemPrice != null)
                    if (itemPrice.Value != "")
                        price.ItemPrice = double.Parse(itemPrice.Value);

                var itemUpdateDate = itemElement.Element("PriceUpdateDate");
                if (itemUpdateDate != null)
                    if (itemUpdateDate.Value != "")
                        price.UpdateDate = DateTime.Parse(itemUpdateDate.Value);

                context.Prices.Add(price);

                context.SaveChanges();
            }
        }

        public void ParseStoresXml(MarketContext context)
        {
            var filePath = string.Format(@"D:\Program Files\GO\GoProjects\bin\Stores7290725900003_201608160753");
            var doc = XDocument.Load(filePath);

            var chain = new Chain();
            var chainId = doc.Element("ChainId");
            if (chainId != null)
                if (chainId.Value != "")
                    chain.ChainID = long.Parse(chainId.Value);

            chain.Name = doc.Element("Store")?.Element("ChainName")?.Value;

            context.Chains.Add(chain);

            foreach (var storeElement in doc.Descendants("Store"))
            {
                var store = new Store();

                var storeId = storeElement.Element("StoreID");
                if (storeId != null)
                    if (storeId.Value != "")
                        store.StoreID = long.Parse(storeId.Value);

                store.Adress = storeElement.Element("Address")?.Value + " , " + storeElement.Element("City")?.Value;

                store.Name = storeElement.Element("StoreName")?.Value;

                context.Stores.Add(store);

                context.SaveChanges();
            }
        }
    }
}
