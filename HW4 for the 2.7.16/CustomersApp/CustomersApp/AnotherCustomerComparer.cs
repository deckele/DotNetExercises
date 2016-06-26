using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer c1, Customer c2)
        {
            return c1.ID - c2.ID;
        }
    }
}
