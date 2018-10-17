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
        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        string AirlineName { get; set; }
        string TravelAgency { get; set; }
        string CustomerNumber { get; set; }
        DateRange BookingDateRange { get; set; }
        DateRange FlightDateRange { get; set; }

        void DoFlightBookingSearch();
    }
}
