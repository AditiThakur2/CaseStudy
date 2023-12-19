using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entities
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }

        public Customers() { }
        public Customers(int customerID, string firstName, string lastName, string email, double phoneNumber)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"CustomerID:: {CustomerID}, Name:: {FirstName} {LastName}, Email:: {Email}, PhoneNo:: {PhoneNumber}";
        }
    }
}
