using System;
using System.Collections.Generic;
using System.Data.Entity; // Import Entity Framework namespace
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    // DbContext class representing the database context for restaurant data
    public class RestaurantData : DbContext
    {

        // Constructor to initialize the DbContext with the connection string
        public RestaurantData(string OODExam_JamesMcaffertyDevers) : base(OODExam_JamesMcaffertyDevers) { }

        // DbSet property to represent the Customers table in the database
        public DbSet<Customer> Customers { get; set; }

        // DbSet property to represent the Bookings table in the database
        public DbSet<Booking> Bookings { get; set; }
    }
}
