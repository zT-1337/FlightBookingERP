using System.Windows;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows
{
    /// <summary>
    /// Interaktionslogik für FlightBookingCreateWindow.xaml
    /// </summary>
    public partial class FlightBookingCreateWindow : Window
    {
        public FlightBookingCreateWindow(IFlightBookingCreateViewModel createViewModel)
        {
            DataContext = createViewModel;

            InitializeComponent();
        }
    }
}
