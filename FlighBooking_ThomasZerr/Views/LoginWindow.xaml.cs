using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlighBooking_ThomasZerr.Views.FlightBookingWindows.Factorys;

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
        }
    }
}
