using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    internal delegate bool CustomerFilter(Customer customer);
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();

            customerList.Add(new Customer("Eli", "Rehovot", 30));
            customerList.Add(new Customer("Alina", "Tel-Aviv", 25));
            customerList.Add(new Customer("Yoheved", "Bne-Brak", 45));
            customerList.Add(new Customer("Eli", "Rehovot", 150));
            customerList.Add(new Customer("Ofer", "Yokneam", 60));

            Console.WriteLine("Initial List:");
            Customer.PrintCustomerList(customerList);

            CustomerFilter cfByFirstLetterAToK = new CustomerFilter(FilterFirstLetter);
            CustomerFilter cfByFirstLetterLToZ = delegate (Customer customer)
            {
                if (customer.Name.ToLower()[0] >= 'l')
                {
                    return true;
                }
                return false;
            };
            CustomerFilter cfIDLessThan100 = (Customer customer) =>
            {
                if (customer.ID < 100)
                {
                    return true;
                }
                return false;
            };

            //Testing the different filter delegates
            Console.WriteLine();
            Console.WriteLine("Showing customers whose names are between A-K:");
            Customer.PrintCustomerList(GetCustomers(customerList, cfByFirstLetterAToK));
            Console.WriteLine();
            Console.WriteLine("Showing customers whose names are between L-Z:");
            Customer.PrintCustomerList(GetCustomers(customerList, cfByFirstLetterLToZ));
            Console.WriteLine();
            Console.WriteLine("Showing customers whose ID numbers are below 100:");
            Customer.PrintCustomerList(GetCustomers(customerList, cfIDLessThan100));
        }

        public static List<Customer> GetCustomers(List<Customer> customerList, CustomerFilter customerFilter)
        {
            if (customerFilter == null)
            {
                return customerList;
            }

            var filteredCustomerList = new List<Customer>();
            foreach (var customer in customerList)
            {
                if (customerFilter(customer))
                {
                    filteredCustomerList.Add(customer);
                }
            }
            return filteredCustomerList;
        }

        public static bool FilterFirstLetter(Customer customer)
        {
            if (customer.Name.ToLower()[0] <= 'k')
            {
                return true;
            }
            return false;
        }
    }
}
