using System.Windows;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows
{
    /// <summary>
    /// Interaktionslogik für FlightBookingEditWindow.xaml
    /// </summary>
    public partial class FlightBookingEditWindow : Window
    {
        public FlightBookingEditWindow(IFlightBookingEditViewModel editViewModel)
        {
            DataContext = editViewModel;
            InitializeComponent();
        }
    }
}
