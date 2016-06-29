using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    internal class AnotherCustomerComparer : IComparer<Customer>
    {
        //Implementing IComperer according to ID.
        public int Compare(Customer c1, Customer c2)
        {
            if ((c1 == null) && (c2 == null))
            {
                return 0;
            }
            else if ((c1 != null) && (c2 == null))
            {
                return 1;
            }
            else if ((c1 == null) && (c2 != null))
            {
                return -1;
            }
            return c1.ID - c2.ID;
        }
    }
}
