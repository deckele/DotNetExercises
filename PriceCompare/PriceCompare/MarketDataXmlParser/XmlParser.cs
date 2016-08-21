using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketDataXmlParser
{
    public class XmlParser
    {
        private string _path;

        public XmlParser()
        {
            _path = null;
        }
        public XmlParser(string path)
        {
            _path = path;
        }

        public void XmlQuery()
        {
            XmlQuery(_path);
        }
        public void XmlQuery(string path)
        {
            _path = path;

            var doc = XDocument.Load(@"C:\Users\amirc_000\Desktop\ConsoleApplication1\ConsoleApplication1\XMLFile1.xml");
            var prices = from items in doc.Root?.Elements()
                         where items.Elements().Any(child => child.Element("Price") != null)
                         from item in items.Elements()
                         let price = item.Element("Price")?.Value
                         where price != null
                         select int.Parse(price);


        }
    }
}
