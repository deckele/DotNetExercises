using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    internal class A : IGreetable
    {
        public string Hello(string inputString)
        {
            return "Hello " + inputString;
        }
    }
}
