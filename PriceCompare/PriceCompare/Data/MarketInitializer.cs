using System;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Xml.Linq;

namespace Data
{
    public class MarketInitializer : DropCreateDatabaseIfModelChanges<MarketContext>
    {
        protected override void Seed(MarketContext context)
        {
        }
    }
}