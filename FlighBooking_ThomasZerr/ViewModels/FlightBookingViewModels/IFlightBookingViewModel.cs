using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    interface IFlightBookingViewModel
    {
        IFlightBooking ChosenFlightBooking { get; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        string AirlineName { get; set; }
        string TravelAgency { get; set; }
        string CustomerNumber { get; set; }
        IDateRange BookingDateRange { get; }
        IDateRange FlightDateRange { get; }

        void DoFlightBookingSearch();
    }
}
