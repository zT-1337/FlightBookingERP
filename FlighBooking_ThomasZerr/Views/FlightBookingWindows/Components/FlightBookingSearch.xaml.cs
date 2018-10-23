﻿using System;
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
using FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows.Components
{
    /// <summary>
    /// Interaktionslogik für FlightBookingSearch.xaml
    /// </summary>
    public partial class FlightBookingSearch : UserControl
    {
        public FlightBookingSearch()
        {
            InitializeComponent();
        }

        private void DoSearch(object sender, RoutedEventArgs e)
        {
            var flightBookingViewModel = (IFlightBookingViewModel) DataContext;
            flightBookingViewModel.DoFlightBookingSearch();
        }
    }
}