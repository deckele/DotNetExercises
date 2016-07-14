using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        private static string InvokeHello(Object obj, string inputString)
        {
            var type = typeof(IGreetable);
            return type.InvokeMember("Hello",BindingFlags.InvokeMethod , null, obj, new object[] {inputString}).ToString();
        }

        static void Main(string[] args)
        {
            var greetingsList = new List<IGreetable>
            {
                new A(),
                new B(),
                new C()
            };

            foreach (var greetableObj in greetingsList)
            {
                Console.WriteLine(InvokeHello(greetableObj, "nurse!"));
            }

        }
    }
}
