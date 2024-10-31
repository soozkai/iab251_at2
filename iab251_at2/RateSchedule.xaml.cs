using System.Collections.Generic;
using System.Windows;
using System.Xml.Serialization;

namespace iab251_at2
{
    public partial class RateSchedule : Window
    {
        //Initalize the component to load up in the program and load the rate schedule into the grid
        public RateSchedule()
        {
            InitializeComponent();
            LoadRateSchedule();
        }
        //Create the rate schedule information and put into the grid
        private void LoadRateSchedule()
        {
            //The information to be inputed into the grid.
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

        //give the close button an action to close the window
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    //define the rate model so that it can load data into each row of the grid
    public class Rate
    {
        public string Type { get; set; }
        public string Fee20Ft { get; set; }
        public string Fee40Ft { get; set; }
    }
}