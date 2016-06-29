using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public Customer(string name, string adress, int id)
        {
            Name = name;
            Adress = adress;
            ID = id;
        }
        
        public string Name { get;  private set; }
        public string Adress { get; private set; }
        public int ID { get; private set; }

        //Implementing IComparable according to Name.
        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                return 1;
            }
            return string.Compare(this.Name, other.Name, true);
        }
        //Implementing IEquatable according to Name and ID.
        public bool Equals(Customer other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.Name == other.Name)
            {
                return this.ID.Equals(other.ID);
            }
            else
            {
                return this.Name.Equals(other.Name);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode()^ID.GetHashCode();
        }

        //For testing- overriding ToString() method
        public override string ToString()
        {
            return string.Format("Name:{0,8}. ID:{1,4}. Adress:{2,8} ", Name, ID, Adress);
        }
        public static void PrintCustomerList(IEnumerable<Customer> customerList)
        {
            foreach (var customer in customerList)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
