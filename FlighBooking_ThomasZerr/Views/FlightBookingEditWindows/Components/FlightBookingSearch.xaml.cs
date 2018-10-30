using System.Windows;
using System.Windows.Controls;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Components
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
            var flightBookingViewModel = (IFlightBookingEditViewModel) DataContext;
            flightBookingViewModel.DoFlightBookingSearch();
        }
    }
}
