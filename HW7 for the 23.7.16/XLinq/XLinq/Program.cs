using System;
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
                                            from publicInstanceProperty in publicClass.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                            orderby publicInstanceProperty.Name
                                            select new XElement("Property",
                                                        new XAttribute("Name", publicInstanceProperty.Name),
                                                        new XAttribute("Type", publicInstanceProperty.PropertyType))),
                                        new XElement("Public_instance_methods",
                                            from publicInstanceMethods in publicClass.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
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
            Console.WriteLine("Lab 4.2 (a):");
            var xmlQuery = from typeWithNoProperty in xml.Descendants("Class")
                           let xElement = typeWithNoProperty.Element("Public_instance_properties")
                           where xElement != null && xElement.IsEmpty
                           orderby (string) typeWithNoProperty.Attribute("Name").Value
                           select typeWithNoProperty.Attribute("Name").Value;

            Console.WriteLine("Names of all types with no properties in \"PublicClassQueryInMsCoreLib.xml\":");
            Console.WriteLine();

            //Using counter variable instead of xmlQuery.Count as to not repeat enumeration process twice.
            int counter = 0;
            foreach (var typeWithNoProperty in xmlQuery)
            {
                Console.WriteLine(typeWithNoProperty);
                counter++;
            }

            Console.WriteLine();
            Console.WriteLine($"Ovrall {counter} types with no properties were found.");
            Console.WriteLine();

            //Lab 4.2 (b)
            //The methods are already not including inherited ones. No need to filter again.
            Console.WriteLine("Lab 4.2 (b):");
            counter = xml.Descendants("Method").Count();
            Console.WriteLine($"Total number of methods: {counter}.");
            Console.WriteLine();

            //Lab 4.2 (c)
            Console.WriteLine("Lab 4.2 (c), some more statistics:");
            counter = xml.Descendants("Property").Count();
            Console.WriteLine($"Total number of Properties: {counter}.");
            Console.WriteLine();

            var parameterQuery = from parameter in xml.Descendants("Parameter")
                                 group parameter by parameter.Attribute("Type").Value into parameterGroup
                                 orderby parameterGroup.Count() descending 
                                 select parameterGroup.Key;

            Console.WriteLine($"The most common parameter type is {parameterQuery.First()}.");
            Console.WriteLine();

            //Lab 4.2 (d)
            var xmlSorted = new XElement("Sorted_Public_Classes_in_MsCoreLib",
                                from type in xml.Descendants("Class")
                                orderby type.Descendants("Method").Count() descending
                                select new XElement("Class",
                                            new XAttribute("Name", type.Attribute("Name").Value),
                                            new XAttribute("Property_Count", type.Descendants("Property").Count()),
                                            new XAttribute("Method_Count", type.Descendants("Method").Count())));
            xmlSorted.Save("SortedPublicClassQueryInMsCoreLib.xml");

            //Lab 4.2 (e)
            Console.WriteLine("Lab 4.2 (e):");

            var sortClassByMethodQuery = from type in xml.Descendants("Class")
                                         orderby type.Attribute("Name").Value
                                         group type by type.Descendants("Method").Count() into methodGroup
                                         orderby methodGroup.Key descending
                                         select methodGroup;

            foreach (var methodGroup in sortClassByMethodQuery)
            {
                Console.WriteLine();
                Console.WriteLine($"Number Of methods in classes: {methodGroup.Key}.");
                Console.WriteLine();

                foreach (var type in methodGroup)
                {
                    Console.WriteLine($"Class name: {type.Attribute("Name")}.");
                }
            }
        }
    }
}

