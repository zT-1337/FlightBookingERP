using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    interface IFlightBookingViewModel
    {
        IFlightBooking ChosenFlightBooking { get; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }
        ObservableCollection<IFlightBooking> CreatedFlightBookings { get; }

        string AirlineName { get; set; }
        string TravelAgency { get; set; }
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
        void DoChooseFlightBooking(int index);
        void DoCreateFlightBooking();
        void DoConfirmFlightBooking();
        void DoCancelFlightBooking();
    }
}
