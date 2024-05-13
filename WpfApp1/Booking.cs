using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfParticipants { get; set; }

        // Foreign key to link Booking to a Customer
        public int CustomerID { get; set; }

        // Navigation property for the inverse one-to-many relationship
        public Customer Customer { get; set; }
    }
}
