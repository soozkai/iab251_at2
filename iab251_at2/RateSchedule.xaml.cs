using System.Collections.Generic;
using System.Windows;

namespace iab251_at2
{
    /// <summary>
    /// Represents a window that displays the rate schedule for various services.
    /// </summary>
    public partial class RateSchedule : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateSchedule"/> class.
        /// </summary>
        public RateSchedule()
        {
            InitializeComponent();
            LoadRateSchedule();
        }

        /// <summary>
        /// Loads the rate schedule information into the data grid.
        /// </summary>
        private void LoadRateSchedule()
        {
            // The information to be inputted into the grid.
            var rates = new List<Rate>
            {
                new Rate { Type = "Walf Booking Fee", Fee20Ft = "$60", Fee40Ft = "$70" },
                new Rate { Type = "Lift on/Lift Off", Fee20Ft = "$80", Fee40Ft = "$120" },
                new Rate { Type = "Fumigation", Fee20Ft = "$220", Fee40Ft = "$280" },
                new Rate { Type = "LCL Delivery Depot", Fee20Ft = "$400", Fee40Ft = "$500" },
                new Rate { Type = "Tailgate Inspection", Fee20Ft = "$120", Fee40Ft = "$160" },
                new Rate { Type = "Storage Fee", Fee20Ft = "$240", Fee40Ft = "$300" },
                new Rate { Type = "Facility Fee", Fee20Ft = "$70", Fee40Ft = "$100" },
                new Rate { Type = "Walf Inspection", Fee20Ft = "$60", Fee40Ft = "$90" },
                new Rate { Type = "GST", Fee20Ft = "10%", Fee40Ft = "10%" }
            };

            RateScheduleDataGrid.ItemsSource = rates;
        }

        /// <summary>
        /// Closes the rate schedule window when the close button is clicked.
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// Represents a rate for a specific service type.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Gets or sets the type of service.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the fee for a 20 ft container.
        /// </summary>
        public string Fee20Ft { get; set; }

        /// <summary>
        /// Gets or sets the fee for a 40 ft container.
        /// </summary>
        public string Fee40Ft { get; set; }
    }
}
