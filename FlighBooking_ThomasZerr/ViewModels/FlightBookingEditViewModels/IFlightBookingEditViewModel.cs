using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.OperationResults;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    public interface IFlightBookingEditViewModel
    {
        IOperationResult OperationResult { get; }

        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; set; }

        string AirlineId { get; set; }
        string TravelAgencyId { get; set; }
        string CustomerId { get; set; }

        DateRangeOption BookingDateRangeOption { get; set; }
        DateTime BookingDateEarlierDateTime { get; set; }
        DateTime BookingDateLaterDateTime { get; set; }

        DateRangeOption FlightDateRangeOption { get; set; }
        DateTime FlightDateEarlierDateTime { get; set; }
        DateTime FlightDateLaterDateTime { get; set; }

        int MaxResults { get; set; }
        bool IsMaxResultsActive { get; set; }

        void DoFlightBookingSearch();
        void DoConfirmFlightBooking();
        void DoCancelFlightBooking();
    }
}
