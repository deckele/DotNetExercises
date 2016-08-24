using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketDataXmlParser
{
    public class XmlParser<TValue>
    {
        //private string _filePath;

        //public XmlParser()
        //{
        //    _filePath = null;
        //}
        //public XmlParser(string filePath)
        //{
        //    _filePath = filePath;
        //}

        //public IEnumerable<TValue> XmlQuery(string elementName)
        //{
        //    return XmlQuery(_filePath, elementName);
        //}
        public IEnumerable<TValue> XmlQuery(string filePath, string elementName)
        {
            var doc = XDocument.Load(filePath);
            var elements = from items in doc.Root?.Elements()
                           where items.Elements().Any(child => child.Element(elementName) != null)
                               from item in items.Elements()
                               let element = item.Element(elementName)?.Value
                               where element != null
                               select element.ParseGenericType<TValue>();
            return elements;
        }

        //public IEnumerable<string> XmlStringQuery(string elementName)
        //{
        //    return XmlStringQuery(_filePath, elementName);
        //}
        //public IEnumerable<string> XmlStringQuery(string filePath, string elementName)
        //{
        //    _filePath = filePath;

        //    var doc = XDocument.Load(@"D:\Program Files\GO\GoProjects\bin\PriceFull7290725900003_001_201608140516.xml");
        //    var stringElements = from items in doc.Root?.Elements()
        //                      where items.Elements().Any(child => child.Element(elementName) != null)
        //                            from item in items.Elements()
        //                            let stringElement = item.Element(elementName)?.Value
        //                            where stringElement != null
        //                            select stringElement.ToLower();
        //    return stringElements;
        //}

        public void FileExtract(string folderPath)
        {
            
        }

        public void XmlParseAll()
        {
            
        }
    }
}
