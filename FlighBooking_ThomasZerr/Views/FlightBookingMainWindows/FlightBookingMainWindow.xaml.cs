using System.Collections.Generic;
using System.ComponentModel;
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

        private List<Window> openedWindows_;

        public FlightBookingMainWindow(IFlightBookingCreateWindowFactory createWindowFactory, IFlightBookingEditWindowFactory editWindowFactory)
        {
            createWindowFactory_ = createWindowFactory;
            editWindowFactory_ = editWindowFactory;
            openedWindows_ = new List<Window>();

            InitializeComponent();
        }

        private void OpenFlightBookingEdit(object sender, RoutedEventArgs e)
        {
            var editWindow = editWindowFactory_.Create();
            editWindow.Show();
            openedWindows_.Add(editWindow);
        }

        private void OpenFlightBookingCreate(object sender, RoutedEventArgs e)
        {
            var createWindow = createWindowFactory_.Create();
            createWindow.Show();
            openedWindows_.Add(createWindow);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            foreach (var window in openedWindows_)
            {
                window.Close();
            }
        }
    }
}
