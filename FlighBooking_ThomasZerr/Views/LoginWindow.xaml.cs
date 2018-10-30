using System.Windows;
using FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys;

namespace FlighBooking_ThomasZerr.Views
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IFlightBookingMainWindowFactory _flightBookingMainWindowFactory;

        public LoginWindow()
        {
            InitializeComponent();
            _flightBookingMainWindowFactory = new FlightBookingMainWindowFactoryImpl();
        }

        private void DoLogin(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            _flightBookingMainWindowFactory.Create(username, password).Show();
            Close();
        }
    }
}
