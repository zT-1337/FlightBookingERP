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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Components
{
    /// <summary>
    /// Interaktionslogik für FlightSearch.xaml
    /// </summary>
    public partial class FlightSearch : UserControl
    {
        public FlightSearch()
        {
            InitializeComponent();
        }

        private void DoSearchFlight(object sender, RoutedEventArgs e)
        {
            var createViewModel = (IFlightBookingCreateViewModel) DataContext;
            createViewModel.DoFlightSearch();
        }
    }
}
