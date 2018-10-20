using System.Windows;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows
{
    /// <summary>
    /// Interaktionslogik für FlightBookingWindow.xaml
    /// </summary>
    partial class FlightBookingWindow : Window
    {
        public FlightBookingWindow(IFlightBookingViewModel flightBookingViewModel)
        {
            DataContext = flightBookingViewModel;
            InitializeComponent();
        }
    }
}
