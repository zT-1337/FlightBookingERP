using System.Windows;
using System.Windows.Controls;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Components
{
    /// <summary>
    /// Interaktionslogik für FlightBookingChoosen.xaml
    /// </summary>
    public partial class FlightBookingChoosen : UserControl
    {
        public FlightBookingChoosen()
        {
            InitializeComponent();
        }

        private void DoConfirm(object sender, RoutedEventArgs e)
        {
            var flightBookingViewModel = (IFlightBookingViewModel) DataContext;
            flightBookingViewModel.DoConfirmFlightBooking();
        }

        private void DoCancel(object sender, RoutedEventArgs e)
        {
            var flightBookingViewModel = (IFlightBookingViewModel)DataContext;
            flightBookingViewModel.DoCancelFlightBooking();
        }
    }
}
