﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ReturnBookings(); // Call the method to retrieve and display bookings
        }

        // Method to retrieve bookings for the selected date
        private void ReturnBookings()
        {
            using (var db = new RestaurantData("OODExam_JamesMcaffertyDevers")) // Initialize DbContext with the connection string
            {
                // Get the selected date from the DatePicker
                DateTime selectedDate = BookingDatePicker.SelectedDate ?? DateTime.Now.Date;

                // Filter bookings by the selected date and include customer information
                var bookingsForDate = db.Bookings
                                        .Where(b => DbFunctions.TruncateTime(b.BookingDate) == selectedDate.Date) // Filter by date
                                        .Include(b => b.Customer) // Include customer information
                                        .ToList(); // Execute the query and materialize results

                // Update ListBox with retrieved bookings
                BookingsList.ItemsSource = bookingsForDate;

                // Calculate and update capacity information
                int totalCapacity = 40;
                int bookedCount = bookingsForDate.Sum(b => b.NumberOfParticipants); // Calculate total number of booked participants
                int availableSpace = totalCapacity - bookedCount; // Calculate available space

                // Update TextBlocks with capacity information
                CapacityTextBlock.Text = totalCapacity.ToString();
                BookedCountTextBlock.Text = bookedCount.ToString();
                AvailableCountTextBlock.Text = availableSpace.ToString();
            }
        }

        // Event handler for the change in selected date in DatePicker
        private void BookingDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ReturnBookings(); // Call method to update bookings for the new selected date
        }

        
    }
}
