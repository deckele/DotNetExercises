﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = new XElement("Public_Classes_in_MsCoreLib",
                from publicClass in typeof(string).Assembly.GetExportedTypes()
                where publicClass.IsClass
                orderby publicClass.Name
                select new XElement("Class",
                    new XAttribute("Name", publicClass.Name),
                    new XElement("Public_instance_properties",
                        from publicInstanceProperty in
                            publicClass.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        orderby publicInstanceProperty.Name
                        select new XElement("Property",
                            new XAttribute("Name", publicInstanceProperty.Name),
                            new XAttribute("Type", publicInstanceProperty.PropertyType))),
                        new XElement("Public_instance_methods",
                            from publicInstanceMethods in
                                publicClass.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                            orderby publicInstanceMethods.Name
                            select new XElement("Method",
                                new XAttribute("Name", publicInstanceMethods.Name),
                                new XAttribute("Return_type", publicInstanceMethods.ReturnType),
                                new XElement("Parameters",
                                    from parameters in publicInstanceMethods.GetParameters()
                                    select new XElement("Parameter",
                                        new XAttribute("Name", parameters.Name),
                                        new XAttribute("Type", parameters.ParameterType)))))));
            xml.Save("PublicClassQueryInMsCoreLib.xml");

            //Lab 4.2 (a)
            var xmlQuery = from typeWithNoProperty in xml.Descendants("Class")
                where typeWithNoProperty.Element("Public_instance_properties").IsEmpty
                orderby (string)typeWithNoProperty.Attribute("Name")
                select typeWithNoProperty;

            Console.WriteLine("Names of all types with no properties in \"PublicClassQueryInMsCoreLib.xml\":");
            Console.WriteLine();
            foreach (var typeWithNoProperty in xmlQuery)
            {
                Console.WriteLine(typeWithNoProperty.Attribute("Name"));
            }

            Console.WriteLine();
            Console.WriteLine($"Ovrall {xmlQuery.Count()} types with no properties were found.");
        }
    }
}

