using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace MainAccounts
{
    class Program
    {
        static void Main(string[] args)
        { 
            UserInterface session1 = new UserInterface();
            session1.AccountCreationMenu();
        }
    }
}
