using System;
using System.Windows;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows
{
    /// <summary>
    /// Interaktionslogik für FlightBookingWindow.xaml
    /// </summary>
    partial class FlightBookingWindow : Window
    {
        private IFlightBookingViewModel flightBookingViewModel_;

        public FlightBookingWindow(IFlightBookingViewModel flightBookingViewModel)
        {
            DataContext = flightBookingViewModel;
            flightBookingViewModel_ = flightBookingViewModel;
            InitializeComponent();
        }

        private void GetListButton(object sender, RoutedEventArgs e)
        {
            flightBookingViewModel_.DoFlightBookingSearch();
        }
    }
}
