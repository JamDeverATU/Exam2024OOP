using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RestaurantData("OODExam_JamesMcaffertyDevers"))
            {
                try
                {
                    // Create customers
                    Customer c1 = new Customer() { Name = "Tom Jones", ContactNumber = "086-123 4567" };
                    Customer c2 = new Customer() { Name = "Mary Smith", ContactNumber = "086 546 3214" };
                    Customer c3 = new Customer() { Name = "Jo Doyle", ContactNumber = "087 1221 222" };

                    // Add customers to the database
                    db.Customers.Add(c1);
                    db.Customers.Add(c2);
                    db.Customers.Add(c3);

                    // Save changes to the database
                    db.SaveChanges();

                    Console.WriteLine("Customers added successfully!");

                    // Create bookings for the customers
                    DateTime bookingDate = new DateTime(2024, 5, 13); // May 13, 2024
                    int partySize = 4; // Assuming each booking is for a party of 4

                    Booking booking1 = new Booking() { BookingDate = bookingDate, NumberOfParticipants = partySize, Customer = c1 };
                    Booking booking2 = new Booking() { BookingDate = bookingDate, NumberOfParticipants = partySize, Customer = c2 };
                    Booking booking3 = new Booking() { BookingDate = bookingDate, NumberOfParticipants = partySize, Customer = c3 };

                    // Add bookings to the database
                    db.Bookings.Add(booking1);
                    db.Bookings.Add(booking2);
                    db.Bookings.Add(booking3);

                    // Save changes to the database
                    db.SaveChanges();

                    Console.WriteLine("Bookings added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database update failed: {ex.Message}");
                }
            }
        }
    }
}
