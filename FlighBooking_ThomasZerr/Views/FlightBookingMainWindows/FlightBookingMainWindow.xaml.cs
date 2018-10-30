using System.Windows;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows
{
    /// <summary>
    /// Interaktionslogik für FlightBookingWindow.xaml
    /// </summary>
    partial class FlightBookingMainWindow : Window
    {
        private IFlightBookingViewModel flightBookingViewModel_;

        public FlightBookingMainWindow(IFlightBookingViewModel flightBookingViewModel)
        {
            DataContext = flightBookingViewModel;
            flightBookingViewModel_ = flightBookingViewModel;
            InitializeComponent();
        }
    }
}
