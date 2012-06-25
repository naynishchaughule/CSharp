using System;
using System.Text;

namespace Shopping
{
    public class Customer
    {
        public Int32 CustomerId { get; set; }
        public String CustomerName { get; set; }
        public StringBuilder CustomerAddress { get; set; }
        public String CustomerPhone { get; set; }

        public Customer() : this (id: 48090, name: "naynish p. chaughule", address: new StringBuilder("2400 Virginia Ave"), 
            customerPhone: "202-714-5352")
        {
                
        }

        public Customer(Int32 id, String name, StringBuilder address, String customerPhone)
        {
            CustomerId = id; CustomerName = name; CustomerAddress = address;
            CustomerPhone = customerPhone;
        }

        public override String ToString()
        {
            return String.Format("Customer details:\nId: {0}, Name: {1}, Address: {2}, Phone: {3}",
                CustomerId, CustomerName, CustomerAddress, CustomerPhone);
        }
    }
}