using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    interface IFlightBookingCreateViewModel
    {
        Exception CaughtException { get; }

        IFlight ChosenFlight { get; set; }
        ObservableCollection<IFlight> RetrievedFlights { get; }

        IFlightBookingData Args { get; }

        void DoFlightSearch();
        void DoCreateFlightBooking();
    }
}
