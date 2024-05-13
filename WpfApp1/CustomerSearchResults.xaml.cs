using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class CustomerSearchResults : Window
    {
        // Assuming you have a list of customers to bind to the ListBox
        public List<Customer> Customers { get; set; }

        public CustomerSearchResults(List<Customer> searchResults)
        {
            InitializeComponent();
            Customers = searchResults;
            DataContext = this;
        }

        private void CreateBookingButton2_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            // Get the selected customer from the ListBox
            Customer selectedCustomer = CustomersListBox.SelectedItem as Customer;

            // You may need to parse or convert the values from UI elements like TextBoxes
            // For example:
            DateTime bookingDate = DateTime.Parse(BookingDateTextBlock.Text);
            int numberOfCustomers = int.Parse(NumberOfCustomersTextBlock.Text);

            // Create a new booking with the selected customer and other details
            Booking newBooking = new Booking
            {
                Customer = selectedCustomer,
                BookingDate = bookingDate,
                NumberOfParticipants = numberOfCustomers
                // You may need to populate other properties of the booking object
            };

            // Assuming you have a method to save the booking
            // SaveBooking(newBooking);

            // Show confirmation message
            MessageBox.Show("Booking created successfully.");

            // Close the window
            this.Close();
        }
    }
}
