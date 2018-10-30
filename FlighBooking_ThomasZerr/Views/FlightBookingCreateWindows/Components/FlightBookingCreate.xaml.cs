using System.Windows;
using System.Windows.Controls;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Components
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
            var flightBookingViewModel = (IFlightBookingCreateViewModel) DataContext;
            flightBookingViewModel.DoCreateFlightBooking();
        }
    }
}
