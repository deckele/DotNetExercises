using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public class AssemblyAnalyzer
    {
        public AssemblyAnalyzer()
        {
        }
        public AssemblyAnalyzer(Assembly assembly)
        {
            AnalayzeAssembly(assembly);
        }

        public bool AnalayzeAssembly(Assembly assembly)
        {
            var allTypesApproved = true;
            var filteredTypeArray = assembly?.GetTypes().Where(type => type.IsDefined(typeof(CodeReviewAttribute)));

            if (filteredTypeArray != null)
            {
                foreach (var type in filteredTypeArray)
                {
                    var attributeArray = type.GetCustomAttributes(typeof(CodeReviewAttribute));

                    foreach (var attribute in attributeArray)
                    {
                        if (!((CodeReviewAttribute) attribute).CodeIsApproved)
                        {
                            allTypesApproved = false;
                        }
                        Console.WriteLine(attribute);
                    }
                }
            }
            return allTypesApproved;
        }
    }
}
