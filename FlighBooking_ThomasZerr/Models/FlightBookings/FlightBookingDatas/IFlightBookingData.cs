using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas
{
    public interface IFlightBookingData
    {
        //TODO Flightdate eventuell in besseren Datentypen umwandeln
        string AirlineId { get; set; }
        string BookingId { get; set; }
        string ConnectId { get; set; }
        IDate Flightdate { get; }
        string CustomerId { get; set; }
        string Class { get; set; }
        IDate Bookdate { get; }
        string Counter { get; set; }
        string AgencyId { get; set; }
        string PassagierName { get; set; }
        bool Reserved { get; set; }
        bool Cancelled { get; set; }
        bool Confirmed { get; }

        IDateRange BookingDateRange { get; }
        IDateRange FlightDateRange { get; }

        void ConfirmFlight();
    }
}
