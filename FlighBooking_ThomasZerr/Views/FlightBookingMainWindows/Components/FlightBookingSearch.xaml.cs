using System.Windows;
using System.Windows.Controls;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Components
{
    /// <summary>
    /// Interaktionslogik für FlightBookingSearch.xaml
    /// </summary>
    public partial class FlightBookingSearch : UserControl
    {
        public FlightBookingSearch()
        {
            InitializeComponent();
        }

        private void DoSearch(object sender, RoutedEventArgs e)
        {
            var flightBookingViewModel = (IFlightBookingViewModel) DataContext;
            flightBookingViewModel.DoFlightBookingSearch();
        }
    }
}
