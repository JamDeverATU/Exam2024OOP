using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Booking
    {
        // Property to hold the ID of the booking
        public int BookingID { get; set; }

        // Property to hold the date of the booking
        public DateTime BookingDate { get; set; }

        // Property to hold the number of participants in the booking
        public int NumberOfParticipants { get; set; }

        // Foreign key to link Booking to a Customer
        public int CustomerID { get; set; }

        // Navigation property for the inverse one-to-many relationship
        public Customer Customer { get; set; }
    }
}
