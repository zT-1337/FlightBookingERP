using System.Windows;
using FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys;

namespace FlighBooking_ThomasZerr.Views
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IFlightBookingWindowFactory flightBookingWindowFactory;

        public LoginWindow()
        {
            InitializeComponent();
            flightBookingWindowFactory = new FlightBookingWindowFactoryImpl();
        }

        private void DoLogin(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            flightBookingWindowFactory.Create(username, password).Show();
            Close();
        }
    }
}
