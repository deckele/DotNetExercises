using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Data;

namespace FileManager
{
    public class MarketXmlParser
    {
        public void FileExtract(string folderPath)
        {

        }

        public void ParseAllXml()
        {
            //ParseStoresXml(context, (@"D:\Program Files\GO\GoProjects\bin\Stores7290873255550-201608202005.xml"));
            //ParsePricesXml(context, (@"D:\Program Files\GO\GoProjects\bin\PriceFull7290873255550-081-201608210010.xml"));
            using (var context = new MarketContext())
            {
                ParseStoresXml(context, (@"D:\Emanuel\Desktop\hararaa\hararaa\Stores7290058140886-201608152005.xml"));
            }
            using (var context = new MarketContext())
            {
                ParseStoresXml(context, (@"D:\Emanuel\Desktop\hararaa\hararaa\Stores7290700100008-201608152005.xml"));
            }
            using (var context = new MarketContext())
            {
                ParsePricesXml(context, (@"D:\Emanuel\Desktop\hararaa\hararaa\Price7290058140886-001-201608150800.xml"));
            }
            using (var context = new MarketContext())
            {
                ParsePricesXml(context, (@"D:\Emanuel\Desktop\hararaa\hararaa\Price7290700100008-001-2016081511001xml.xml"));
            }
        }

        public void ParseStoresXml(MarketContext context, string filePath)
        {
            var doc = XDocument.Load(filePath);

            //Root element query for ChainId, ChainName and LastUpdateDate, creating "Chain" object:
            long chainId;
            long.TryParse(doc.Root?.Element("ChainId")?.Value, out chainId);
            string chainName = doc.Root?.Element("ChainName")?.Value;
            DateTime lastUpdateDate;
            DateTime.TryParse(doc.Root?.Element("LastUpdateDate")?.Value, out lastUpdateDate);

            if (context.Chains.Find(chainId) == null)
            {
                var chain = new Chain()
                {
                    ChainID = chainId,
                    Name = chainName
                };
                context.Chains.AddOrUpdate(chain);
                context.SaveChanges();
            }

            //Link to xml query for all other fields, creating "Store" object: 
            long storeId = -1;
            var storesData = from element in doc.Descendants("StoreId")
                             let storeElement = element.Parent
                             where long.TryParse(storeElement.Element("StoreId")?.Value, out storeId) //Choose only elements where StoreID can be parsed
                             select new Store()
                                {
                                    StoreID = storeId,
                                    ChainID = chainId,
                                    Name = storeElement.Element("StoreName")?.Value,
                                    Address = storeElement.Element("Address")?.Value,
                                    City = storeElement.Element("City")?.Value,
                                    UpdateDate = lastUpdateDate,
                                    Chain = context.Chains.Find(chainId) //Store object has a chain object in a one to one DB relationship.
                                };
            
            var uniqueStoresList = storesData.Distinct();
            //var uniqueStoresNotInDatabase = uniqueStoresData;

            //var chainDuplicate = context.Chains.Find(chain.ChainID); //Check for duplicates in database
            //if (chainDuplicate != null)
            //{
            //    context.Chains.Remove(chainDuplicate);
            //    context.SaveChanges();
            //}
            //context.Chains.AddOrUpdate(chain);
            context.Stores.AddRange(uniqueStoresList);
            //var duplicateStores = context.Stores.Local.Union(context.Stores);
            //context.Stores.RemoveRange(duplicateStores);
            context.SaveChanges();
        }

        public void ParsePricesXml(MarketContext context, string filePath)
        {
            var doc = XDocument.Load(filePath);

            //Root element query for ChainId, and StoreId, for finding a Store Object later:
            long chainId;
            long.TryParse(doc.Root?.Element("ChainId")?.Value, out chainId);
            long storeId;
            long.TryParse(doc.Root?.Element("StoreId")?.Value, out storeId);
            
            //Link to xml query for all other fields, creating "Item" and "Price" objects:
            long itemId = -1;
            var newItemsData = (from element in doc.Descendants("ItemCode")
                               let itemElement = element.Parent
                               //Choose only if itemElements can be parsed...
                               where long.TryParse(itemElement.Element("ItemCode")?.Value, out itemId)
                               where (context.Items.Find(itemId) == null)
                               select new Item()
                               {
                                   //If ItemID has less than 9 digits, it is actually an Inner barcode.
                                   //If item has an inner barcode, the new unique ItemID is (itemId * storeId) ^ chainId * -1:
                                   ItemID = (itemId < 100000000) ? ((itemId*storeId) ^ chainId*-1) : itemId,
                                   Name = itemElement.Element("ItemName")?.Value,
                                   Units = itemElement.Element("UnitOfMeasure")?.Value,
                                   UnitsQuantity = itemElement.Element("Quantity")?.Value,
                                   QuantityInPackage = itemElement.Element("QtyInPackage")?.Value,
                                   InnerBarcode = (itemId < 100000000) ? itemId : 0
                               }).Distinct();

            context.Items.AddRange(newItemsData);
            context.SaveChanges();
            //var itemsDataNotInDb = (from itemData in newItemsData
            //                       where context.Items.Contains(itemData)
            //                       select itemData).ToDictionary(itemData => itemData.ItemID, itemData => itemData);
            
            double itemPrice = -1;
            //Item item = null;
            DateTime updateDate = default(DateTime);
            var pricesData = from element in doc.Descendants("ItemCode")
                             let itemElement = element.Parent
                             //Choose only if itemElements can be parsed...
                             where long.TryParse(itemElement.Element("ItemCode")?.Value, out itemId)
                             //where (itemsDataNotInDb.TryGetValue(itemId, out item))
                             where double.TryParse(itemElement.Element("ItemPrice")?.Value, out itemPrice)
                             where DateTime.TryParse(itemElement.Element("PriceUpdateDate")?.Value, out updateDate)
                             select new Price()
                             {
                                 //If ItemID has less than 9 digits, it is actually an Inner barcode.
                                 //If item has an inner barcode, the new unique ItemID is (itemId * storeId) ^ chainId * -1:
                                 ItemID = (itemId < 100000000) ? ((itemId * storeId) ^ chainId * -1) : itemId,
                                 StoreID = storeId,
                                 ChainID = chainId,
                                 ItemPrice = itemPrice,
                                 UpdateDate = updateDate,
                                 //"Price" object has a "Store" object in a one to many DB relationship.
                                 Store = context.Stores.Find(chainId, storeId), 
                                 //"Price" object contains an "item" object in a one to many DB relationship.
                                 Item = context.Items.Find(itemId)
                             };
            //var pricesList = pricesData.ToList();
            //var newItemIds = pricesList.Select(p => p.Item.ItemID).Distinct().ToArray();
            //var itemsInDb = context.Items.Where(i => newItemIds.Contains(i.ItemID))
            //                             .Select(i => i.ItemID).ToArray();
            //var itemsNotInDb = pricesList.Where(p => !itemsInDb.Contains(p.Item.ItemID));
            //foreach (var price in itemsNotInDb)
            //{
            //    context.Items.Add(price.Item);
            //}
            //context.Configuration.AutoDetectChangesEnabled = false;

            var uniquePricesData = pricesData.Distinct();
            //foreach (var price in uniquePricesDataList)
            //{
            //    var duplicateItem = context.Items.Find(price.ItemID);
            //    if (duplicateItem != null)
            //        context.Items.Remove(duplicateItem);
            //    context.SaveChanges();
            //    context.Items.Add(price.Item);
            //    var duplicatePrice = context.Prices.Find(price.ItemID, price.StoreID, price.ChainID);
            //    if (duplicatePrice != null)
            //        context.Prices.Remove(duplicatePrice);
            //    context.SaveChanges();
            //    context.Prices.Add(price);
            //}
            context.Prices.AddRange(uniquePricesData);
            context.SaveChanges();
        }

        public void InitializeDatabase(MarketContext context)
        {
            context.Prices.RemoveRange(context.Prices);
            context.Items.RemoveRange(context.Items);
            context.Stores.RemoveRange(context.Stores);
            context.Chains.RemoveRange(context.Chains);
            context.SaveChanges();
            //Another way using Sql commands:
            //context.Database.ExecuteSqlCommand("DELETE dbo.Prices");
            //context.Database.ExecuteSqlCommand("DELETE dbo.Items");
            //context.Database.ExecuteSqlCommand("DELETE dbo.Stores");
            //context.Database.ExecuteSqlCommand("DELETE dbo.Chains");
        }
    }
}
