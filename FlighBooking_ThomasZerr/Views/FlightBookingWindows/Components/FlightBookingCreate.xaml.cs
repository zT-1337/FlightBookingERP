using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows.Components
{
    /// <summary>
    /// Interaktionslogik für FlightBookingCreate.xaml
    /// </summary>
    public partial class FlightBookingCreate : UserControl
    {
        public FlightBookingCreate()
        {
            InitializeComponent();
        }

        private void DoCreate(object sender, RoutedEventArgs e)
        {
            var flightBookingViewModel = (IFlightBookingViewModel) DataContext;
            flightBookingViewModel.DoCreateFlightBooking();
        }
    }
}
