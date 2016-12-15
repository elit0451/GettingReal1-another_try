using System.Collections.Generic;

namespace PrettyHair1
{
    public class CustomerRepository
    {
        Dictionary<string, Customer> listofCustomers = new Dictionary<string, Customer>();
        public void Clear()
        {
            listofCustomers.Clear();
            
        }
        public int CountCustomers()
        {
            int numberOfCustomers = listofCustomers.Count;
            return numberOfCustomers;
        }
        public Customer Create(string firstName, string lastName, string phone)
        {
            Customer customer = new Customer(firstName, lastName, phone);
            listofCustomers.Add(phone, customer);
            return customer;
        }

        public Customer Load(string phone)
        {
            if (listofCustomers.ContainsKey(phone))
            {
                return listofCustomers[phone];
            }
            else
            {
                return new Customer();
            }
        }

        public void Delete(string phone)
        {
            listofCustomers.Remove(phone);
        }

        
    }
}
