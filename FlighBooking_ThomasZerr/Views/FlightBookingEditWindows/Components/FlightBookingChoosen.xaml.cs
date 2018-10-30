using System.Windows;
using System.Windows.Controls;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

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
            var flightBookingViewModel = (IFlightBookingEditViewModel) DataContext;
            flightBookingViewModel.DoConfirmFlightBooking();
        }

        private void DoCancel(object sender, RoutedEventArgs e)
        {
            var flightBookingViewModel = (IFlightBookingEditViewModel) DataContext;
            flightBookingViewModel.DoCancelFlightBooking();
        }
    }
}
