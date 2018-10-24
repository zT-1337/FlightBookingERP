using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    public interface IFlightBookingViewModel
    {
        Exception CaughtException { get; }

        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }
        ObservableCollection<IFlightBooking> CreatedFlightBookings { get; }

        IFlightBookingData Args { get; }

        void DoFlightBookingSearch();
        void DoCreateFlightBooking();
        void DoConfirmFlightBooking();
        void DoCancelFlightBooking();
    }
}
