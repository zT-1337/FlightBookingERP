using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.OperationResult;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    public interface IFlightBookingCreateViewModel
    {
        IOperationResult OperationResult { get; }

        ObservableCollection<IFlight> RetrievedFlights { get; set; }

        IFlight ChosenFlight { get; set; }

        string AirlineIdForSearch { get; set; }
        DateRangeOption FlightDateRangeOption { get; set; }
        DateTime FlightDateEarlierDateTime { get; set; }
        DateTime FlightDateLaterDateTime { get; set; }
        int MaxResults { get; set; }
        bool IsMaxResultsActive { get; set; }

        string AirlineIdForCreate { get; set; }
        string TravelAgencyId { get; set; }
        string FlightClass { get; set; }
        string CustomerId { get; set; }
        string PassagierName { get; set; }
        bool IsReserved { get; set; }

        void DoFlightSearch();
        void DoCreateFlightBooking();
    }
}
