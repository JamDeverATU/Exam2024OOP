using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class CustomerSearchResults : Window
    {
        private RestaurantData _context;
        private Customer _selectedCustomer;
        private object context;
        private object matchingCustomers;

        public CustomerSearchResults(RestaurantData context)
        {
            InitializeComponent();
            _context = context;
            CustomersListBox.ItemsSource = _context.Customers; // Assuming CustomersListBox is bound to a collection of Customer objects
        }

        public CustomerSearchResults(object context, object matchingCustomers)
        {
            this.context = context;
            this.matchingCustomers = matchingCustomers;
        }

        private void CreateBookingButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer from the search results.");
                return;
            }

            // Get booking details from UI or other sources
            DateTime bookingDate = DateTime.Now; // Example
            int numberOfCustomers = 2; // Example

            Booking newBooking = new Booking
            {
                BookingDate = bookingDate,
                NumberOfParticipants = numberOfCustomers,
                Customer = _selectedCustomer
            };

            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            MessageBox.Show("Booking created successfully!");
            this.Close();
        }

        private void CustomersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCustomer = (Customer)CustomersListBox.SelectedItem;
        }
    }
}
