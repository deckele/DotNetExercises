using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
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

        public void ParseAllXml(MarketContext context)
        {
            ParseStoresXml(context, (@"D:\Program Files\GO\GoProjects\bin\Stores7290725900003_201608170515.xml"));
            ParsePricesXml(context, (@"D:\Program Files\GO\GoProjects\bin\PriceFull7290725900003_001_201608140516.xml"));

            context.SaveChanges();
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

            var chain = new Chain()
            {
                ChainID = chainId,
                Name = chainName
            };

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
                                    Chain = chain //Store object has a chain object in a one to one DB relationship.
                                };

            var uniqueStoresList = storesData.ToList().Distinct();
            var uniqueStoresNotInDatabase = uniqueStoresList.Except(context.Stores);
            if (context.Chains.Find(chain.ChainID) == null)
            {
                context.Chains.Add(chain);
            }
            context.Stores.AddRange(uniqueStoresNotInDatabase);
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
            double itemPrice = -1;
            DateTime updateDate = default(DateTime);
            var pricesData = from element in doc.Descendants("ItemCode")
                             let itemElement = element.Parent
                             where long.TryParse(itemElement.Element("ItemCode")?.Value, out itemId) //Choose only if itemElements can be parsed...
                             where double.TryParse(itemElement.Element("ItemPrice")?.Value, out itemPrice)
                             where DateTime.TryParse(itemElement.Element("PriceUpdateDate")?.Value, out updateDate)
                             select new Price()
                             {
                                 ItemPrice = itemPrice,
                                 UpdateDate = updateDate,
                                 Store = context.Stores.Find(storeId, chainId), //"Price" object has a "Store" object in a one to many DB relationship.
                                 Item = new Item() //"Price" object has an "item" object in a one to many DB relationship.
                                 {
                                     //If ItemID has less than 9 digits, it is actually an Inner barcode.
                                     //If item has an inner barcode, the new unique ItemID is itemId*chainId*storeId:
                                     ItemID = (itemId < 100000000) ? (itemId*chainId*storeId) : itemId, 
                                     Name = itemElement.Element("ItemName")?.Value,
                                     Units = itemElement.Element("UnitOfMeasure")?.Value,
                                     UnitsQuantity = itemElement.Element("Quantity")?.Value,
                                     QuantityInPackage = itemElement.Element("QtyInPackage")?.Value,
                                     InnerBarcode = (itemId < 100000000) ? itemId : 0
                                 }
                             };

            var uniquePricesList = pricesData.ToList().Distinct();
            var uniquePricesNotInDatabase = uniquePricesList.Except(context.Prices);
            context.Prices.AddRange(uniquePricesNotInDatabase);

            var itemsData = from price in uniquePricesNotInDatabase
                            select price.Item;

            var uniqueItemsList = itemsData.ToList().Distinct();
            var uniqueItemsNotInDatabase = uniqueItemsList.Except(context.Items);
            context.Items.AddRange(uniqueItemsNotInDatabase);
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
