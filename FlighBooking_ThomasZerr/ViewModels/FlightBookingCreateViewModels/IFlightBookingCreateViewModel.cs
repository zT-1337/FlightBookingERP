using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    public interface IFlightBookingCreateViewModel
    {
        Exception CaughtException { get; }

        IFlight ChosenFlight { get; set; }
        ObservableCollection<IFlight> RetrievedFlights { get; }

        IFlightData FlightArgs { get; }
        IFlightBookingData FlightBookingArgs { get; }

        void DoFlightSearch();
        void DoCreateFlightBooking();
    }
}
