using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    interface IFlightBookingData
    {
        //TODO Flightdate eventuell in besseren Datentypen umwandeln
        string AirlineId { get; set; }
        string BookingId { get; set; }
        string ConnectId { get; set; }
        string Flightdate { get; set; }
        string CustomerId { get; set; }
        string Class { get; set; }
        string Bookdate { get; set; }
        string Counter { get; set; }
        string AgencyId { get; set; }
        string PassagierName { get; set; }
        bool Reserved { get; set; }
        bool Cancelled { get; set; }
        bool Confirmed { get; }

        string AirlineName { get; set; }
        string TravelAgency { get; set; }
        IDateRange BookingDateRange { get; }
        IDateRange FlightDateRange { get; }

        void ConfirmFlight();
    }
}
