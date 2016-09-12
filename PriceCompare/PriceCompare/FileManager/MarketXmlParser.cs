﻿using System;
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
        public void ParseAllXml(string directory)
        {
            var fileExtractor = new FileExtractor();
            fileExtractor.DecompressGzFiles(directory, "PriceFull");

            var storesXmls = fileExtractor.GetXmlFilePaths(directory, "Stores");
            foreach (var storeXml in storesXmls)
            {
                using (var context = new MarketContext())
                {
                    ParseStoresXml(context, storeXml);
                }
            }

            var priceFullXmls = fileExtractor.GetXmlFilePaths(directory, "PriceFull");
            foreach (var priceFullXml in priceFullXmls)
            {
                using (var context = new MarketContext())
                {
                    ParsePricesXml(context, priceFullXml);
                }
            }
        }

        public void ParseStoresXml(MarketContext context, string filePath)
            #region Parse and add Chains to DB
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
            context.Chains.AddOrUpdate(chain);
            context.SaveChanges();
            #endregion
            #region Parse and add Stores to DB
            //Link to xml query for all other fields, creating "Store" object: 
            long storeId = -1;
            var storesData = (from element in doc.Descendants("StoreId")
                             let storeElement = element.Parent
                             //Choose only elements where StoreID can be parsed
                             where long.TryParse(storeElement.Element("StoreId")?.Value, out storeId)
                             select new Store()
                                {
                                    StoreID = storeId,
                                    ChainID = chainId,
                                    Name = storeElement.Element("StoreName")?.Value,
                                    Address = storeElement.Element("Address")?.Value,
                                    City = storeElement.Element("City")?.Value,
                                    UpdateDate = lastUpdateDate,
                                    //Store object has a chain object in a one to one DB relationship.
                                    Chain = context.Chains.Find(chainId) 
                                }).Distinct();

            foreach (var store in storesData)
            {
                context.Stores.AddOrUpdate(store);
            }
            context.SaveChanges();
            #endregion
        }


        public void ParsePricesXml(MarketContext context, string filePath)
        {
            #region Parse and add Items to DB
            var doc = XDocument.Load(filePath);
            //Root element query for ChainId, and StoreId, for finding a Store Object later:
            long chainId;
            long.TryParse(doc.Root?.Element("ChainId")?.Value, out chainId);
            long storeId;
            long.TryParse(doc.Root?.Element("StoreId")?.Value, out storeId);
            
            //Link to xml query for all other fields, creating "Item" and then "Price" objects:
            long itemId = -1;
            var newItemsData = (from element in doc.Descendants("ItemCode")
                               let itemElement = element.Parent
                               //Choose only if itemElements can be parsed...
                               where long.TryParse(itemElement.Element("ItemCode")?.Value, out itemId)
                               //If ItemID has less than 9 digits, it is actually an Inner barcode.
                               //If item has an inner barcode, it can't be compared without individual mapping.
                               where itemId >= 100000000
                               select new Item()
                               {
                                   ItemID = itemId,
                                   Name = itemElement.Element("ItemName")?.Value,
                                   Units = itemElement.Element("UnitOfMeasure")?.Value,
                                   UnitsQuantity = itemElement.Element("Quantity")?.Value,
                                   QuantityInPackage = itemElement.Element("QtyInPackage")?.Value,
                               }).Distinct();

            foreach (var item in newItemsData)
            {
                context.Items.AddOrUpdate(item);
            }
            context.SaveChanges();
            #endregion
            #region Parse and add Prices to DB
            double itemPrice = -1;
            DateTime updateDate = default(DateTime);
            var pricesData = (from element in doc.Descendants("ItemCode")
                             let itemElement = element.Parent
                             //Choose only if itemElements can be parsed...
                             where long.TryParse(itemElement.Element("ItemCode")?.Value, out itemId)
                             where itemId >= 100000000
                             where double.TryParse(itemElement.Element("ItemPrice")?.Value, out itemPrice)
                             where DateTime.TryParse(itemElement.Element("PriceUpdateDate")?.Value, out updateDate)
                             select new Price()
                             {
                                 ItemID = itemId,
                                 StoreID = storeId,
                                 ChainID = chainId,
                                 ItemPrice = itemPrice,
                                 UpdateDate = updateDate,
                                 //"Price" object contains a "Store" object in a one to many DB relationship.
                                 Store = context.Stores.Find(chainId, storeId), 
                                 //"Price" object contains an "item" object in a one to many DB relationship.
                                 Item = context.Items.Find(itemId)
                             }).Distinct();

            foreach (var price in pricesData)
            {
                //if (!context.Prices.Contains(price))
                //    context.Prices.Add(price);
                //else
                context.Prices.AddOrUpdate(price); 
            }
            context.SaveChanges();
            #endregion
        }

        private void InitializeDatabase(MarketContext context)
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
