using MarketDataXmlParser;

namespace Data
{
    public class MarketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MarketContext>
    {
        protected override void Seed(MarketContext context)
        {
            foreach (var VARIABLE in COLLECTION)
            {
                
            }
            Item item = new Item();
            item.Price = new XmlParser<double>().XmlQuery("ItemPrice", @"D:\Program Files\GO\GoProjects\bin\PriceFull7290725900003_001_201608140516.xml");
            context.Items.Add(item);
        }
    }
}