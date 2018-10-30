using System.Windows;
using FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys;
using FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys;

namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows
{
    /// <summary>
    /// Interaktionslogik für FlightBookingWindow.xaml
    /// </summary>
    partial class FlightBookingMainWindow : Window
    {
        private IFlightBookingCreateWindowFactory createWindowFactory_;
        private IFlightBookingEditWindowFactory editWindowFactory_;

        public FlightBookingMainWindow(IFlightBookingCreateWindowFactory createWindowFactory, IFlightBookingEditWindowFactory editWindowFactory)
        {
            createWindowFactory_ = createWindowFactory;
            editWindowFactory_ = editWindowFactory;

            InitializeComponent();
        }
    }
}
