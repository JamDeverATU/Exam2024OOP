using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Customer
    {
        // Property to hold the ID of the customer
        public int CustomerID { get; set; }

        // Property to hold the name of the customer
        public string Name { get; set; }

        // Property to hold the contact number of the customer
        public string ContactNumber { get; set; }

        // Navigation property for one-to-many relationship with Booking
        public ICollection<Booking> Bookings { get; set; }

        // Constructor to initialize the Bookings collection
        public Customer()
        {
            Bookings = new List<Booking>(); // Initialize an empty collection for Bookings
        }
    }
}
