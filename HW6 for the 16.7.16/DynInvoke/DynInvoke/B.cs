using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    internal class B : IGreetable
    {
        public string Hello(string inputString)
        {
            return "Bonjour " + inputString;
        }
    }
}
