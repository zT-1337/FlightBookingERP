using System.Windows;
using System.Windows.Controls;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Components
{
    /// <summary>
    /// Interaktionslogik für FlightSearch.xaml
    /// </summary>
    public partial class FlightSearch : UserControl
    {
        public FlightSearch()
        {
            InitializeComponent();
        }

        private void DoSearchFlight(object sender, RoutedEventArgs e)
        {
            var createViewModel = (IFlightBookingCreateViewModel) DataContext;
            createViewModel.DoFlightSearch();
        }
    }
}
