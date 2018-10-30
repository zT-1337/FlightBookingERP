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
