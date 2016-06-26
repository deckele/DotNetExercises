using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();

            customerList.Add(new Customer("Eli", "Rehovot", 30));
            customerList.Add(new Customer("Alina", "Tel-Aviv", 25));
            customerList.Add(new Customer("Yoheved", "Bne-Brak", 45));
            customerList.Add(new Customer("Eli", "Rehovot", 90));
            customerList.Add(new Customer("Ofer", "Yokneam", 60));

            List<Customer> customerList2 = new List<Customer>(customerList);

            Console.WriteLine("Unsorted list:");
            foreach (Customer customer in customerList)
            {
                Console.WriteLine("Name: {0}. ID: {1}. Adress: {2} ", customer.Name, customer.ID, customer.Adress);
            }
            Console.WriteLine();

            //Displaying sorting according to Name ID.
            customerList.Sort();
            Console.WriteLine("Sorted list according to name and then ID:");
            foreach (Customer customer in customerList)
            {
                Console.WriteLine("Name: {0}. ID: {1}. Adress: {2} ", customer.Name, customer.ID, customer.Adress);
            }
            Console.WriteLine();

            //Displaying sorting using AnotherCustomerList, only according to ID.
            AnotherCustomerComparer anotherCustomerComparer = new AnotherCustomerComparer();

            customerList2.Sort(anotherCustomerComparer);

            Console.WriteLine("Sorted list only according to ID:");
            foreach (Customer customer in customerList2)
            {                
                Console.WriteLine("Name: {0}. ID: {1}. Adress: {2} ", customer.Name, customer.ID, customer.Adress);
            }
        }
    }
}
