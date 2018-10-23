using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    public interface IFlightBookingViewModel
    {
        Exception CaughtException { get; }

        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }
        ObservableCollection<IFlightBooking> CreatedFlightBookings { get; }

        string CustomerId { get; set; }
        IDateRange BookingDateRange { get; }
        IDateRange FlightDateRange { get; }

        string AgencyId { get; set; }
        string AirlineId { get; set; }
        string Class { get; set; }
        string ConnectId { get; set; }
        string Counter { get; set; }
        string Flightdate { get; set; }
        string PassagierName { get; set; }
        bool Reserved { get; set; }

        void DoFlightBookingSearch();
        void DoCreateFlightBooking();
        void DoConfirmFlightBooking();
        void DoCancelFlightBooking();
    }
}
