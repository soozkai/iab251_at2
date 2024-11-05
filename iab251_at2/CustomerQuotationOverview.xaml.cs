using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    /// <summary>
    /// Represents the overview page for customer quotations, allowing customers to view their quotations and notifications.
    /// </summary>
    public partial class CustomerQuotationOverview : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerQuotationOverview"/> class.
        /// Loads the quotations and displays notifications on page load.
        /// </summary>
        public CustomerQuotationOverview()
        {
            InitializeComponent();
            LoadQuotations();
            ShowNotifications(); // Call to display notifications on page load
        }

        /// <summary>
        /// Loads the customer's quotations into the view.
        /// </summary>
        private void LoadQuotations()
        {
            QuotationListView.ItemsSource = new List<Quotation>
            {
                new Quotation
                {
                    QuotationNumber = "Q1234",
                    DateIssued = DateTime.Now.AddDays(-2),
                    Status = "Pending",
                    ClientName = "John Doe",
                    ContainerType = "20 ft",
                    Scope = "Electronics Import",
                    DepotCharges = 150.00m,
                    LCLCharges = 200.00m
                },
                new Quotation
                {
                    QuotationNumber = "Q1235",
                    DateIssued = DateTime.Now.AddDays(-1),
                    Status = "Accepted",
                    ClientName = "Jane Smith",
                    ContainerType = "40 ft",
                    Scope = "Textiles Export",
                    DepotCharges = 250.00m,
                    LCLCharges = 300.00m
                }
            };
        }

        /// <summary>
        /// Displays any unread notifications for the customer when the page is loaded.
        /// </summary>
        private void ShowNotifications()
        {
            var notifications = NotificationService.GetUnreadNotifications();
            foreach (var notification in notifications)
            {
                MessageBox.Show(notification.Message, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                notification.IsRead = true; // Mark notification as read
            }
        }

        /// <summary>
        /// Handles the click event for viewing the details of a selected quotation.
        /// Navigates to the <see cref="CustomerQuotationDetails"/> page with the selected quotation.
        /// </summary>
        /// <param name="sender">The button that was clicked.</param>
        /// <param name="e">The event data for the click event.</param>
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Quotation selectedQuotation = button.DataContext as Quotation;
            if (selectedQuotation != null)
            {
                // Navigate to CustomerQuotationDetails page, passing the selected quotation
                NavigationService?.Navigate(new CustomerQuotationDetails(selectedQuotation));
            }
        }
    }
}
