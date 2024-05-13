using System;
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
            ReturnBookings();
        }

        private void ReturnBookings()
        {
            using (var db = new RestaurantData("OODExam_JamesMcaffertyDevers"))
            {
                // Get the selected date from the DatePicker
                DateTime selectedDate = BookingDatePicker.SelectedDate ?? DateTime.Now.Date;

                // Filter bookings by the selected date and include customer information
                var bookingsForDate = db.Bookings
                                        .Where(b => DbFunctions.TruncateTime(b.BookingDate) == selectedDate.Date)
                                        .Include(b => b.Customer) // Include customer information
                                        .ToList();

                // Update ListBox with retrieved bookings
                BookingsList.ItemsSource = bookingsForDate;

                // Update capacity information
                int totalCapacity = 40;
                int bookedCount = bookingsForDate.Sum(b => b.NumberOfParticipants);
                int availableSpace = totalCapacity - bookedCount;

                // Update TextBlocks
                CapacityTextBlock.Text = totalCapacity.ToString();
                BookedCountTextBlock.Text = bookedCount.ToString();
                AvailableCountTextBlock.Text = availableSpace.ToString();
            }
        }



        private void BookingDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ReturnBookings();
        }
    }
}
