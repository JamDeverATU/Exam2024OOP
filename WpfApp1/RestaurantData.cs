using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class RestaurantData : DbContext
    {
        public RestaurantData(string OODExam_JamesMcaffertyDevers) : base(OODExam_JamesMcaffertyDevers) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
