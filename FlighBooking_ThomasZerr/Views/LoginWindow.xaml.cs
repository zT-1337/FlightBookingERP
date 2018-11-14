using System.Windows;
using FlighBooking_ThomasZerr.ViewModels.UserDataViewModels;
using FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys;

namespace FlighBooking_ThomasZerr.Views
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserDataViewModel userDataViewModel_;
        private readonly IFlightBookingMainWindowFactory flightBookingMainWindowFactory_;

        public LoginWindow()
        {
            InitializeComponent();
            userDataViewModel_ = new UserDataViewModelImpl();
            DataContext = userDataViewModel_;
            flightBookingMainWindowFactory_ = new FlightBookingMainWindowFactoryImpl();
        }

        private void DoLogin(object sender, RoutedEventArgs e)
        {
            if (!userDataViewModel_.IsLoginValid())
                return;

            flightBookingMainWindowFactory_.Create(userDataViewModel_.Username, userDataViewModel_.Password).Show();
            Close();
        }
    }
}
