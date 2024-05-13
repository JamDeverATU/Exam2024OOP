using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        // Navigation property for one-to-many relationship with Booking
        public ICollection<Booking> Bookings { get; set; }

        public Customer()
        {
            Bookings = new List<Booking>(); // Initialize an empty collection for Bookings
        }
    }
}
