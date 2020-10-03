using System;
using System.Collections.Generic;


namespace CSharp
{
    public class Customer
    {
        public Customer(int customerID, string name, string address, long phonenumber)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            PhoneNumber = phonenumber;
            //this.CustomerID = CustomerID;
            //this.Name = Name;
            //this.Address = Address;
            //this.PhoneNumber = PhoneNumber;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double PhoneNumber { get; set; }
    }
    interface ICustomerManager
    {
        bool AddCustomer(Customer cs);
        bool DeleteCustomer(int id);
        bool UpdateCustomer(int id);
        bool ViewAllCustomer();
    }
    class CustomerManager : ICustomerManager
    {
        HashSet<Customer> cust = new HashSet<Customer>();
        public bool AddCustomer(Customer cs)
        {
            return cust.Add(cs);
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer cs in cust)
            {
                if (cs.CustomerID == id)
                {
                    cust.Remove(cs);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateCustomer(int id)
        {
            foreach (Customer cs in cust)
            {
                if (cs.CustomerID == id)
                {
                    Console.Write("Enter the New Name: ");
                    string newname = Console.ReadLine();
                    Console.Write("Enter the New Address: ");
                    string newaddress = Console.ReadLine();
                    Console.Write("Enter the New PhoneNumber: ");
                    long newphonenumber = long.Parse(Console.ReadLine());
                    cs.Name = newname;
                    cs.Address = newaddress;
                    cs.PhoneNumber = newphonenumber;
                    return true;
                }
            }
            return false;
        }
        public bool ViewAllCustomer()
        {
            foreach (var cs in cust)
            {
                //Console.WriteLine("-------------------------------");
                Console.WriteLine($"Customer ID: {cs.CustomerID}");
                Console.WriteLine($"Name: {cs.Name}");
                Console.WriteLine($"Address: {cs.Address}");
                Console.WriteLine($"PhoneNumber: {cs.PhoneNumber}");
                Console.WriteLine("---------------------------------");
            }
            return true;
        }
    }

    class Collection
    {
        static void Main(string[] args)
        {
            Customer cs1 = new Customer(1, "Harshitha", "Mysuru", 932462346);
            Customer cs2 = new Customer(2, "Kavya", "Delhi", 8475773822);
            Customer cs3 = new Customer(3, "Pooja", "Bangalore", 957856263);
            CustomerManager mgr = new CustomerManager();
            mgr.AddCustomer(cs1);
            mgr.AddCustomer(cs2);
            mgr.AddCustomer(cs3);
            Console.WriteLine("View of all Customers");
            Console.WriteLine("\n");
            mgr.ViewAllCustomer();
            Console.WriteLine("\n");
            Console.WriteLine("Updating Customer......");
            Console.WriteLine("\n");
            mgr.UpdateCustomer(1);
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Updated Customer Details");
            mgr.ViewAllCustomer();


        }

    }
}
