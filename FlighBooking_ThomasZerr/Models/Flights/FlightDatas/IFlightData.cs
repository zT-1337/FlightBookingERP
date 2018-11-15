using FlighBooking_ThomasZerr.Models.Dates;

namespace FlighBooking_ThomasZerr.Models.Flights.FlightDatas
{
    public interface IFlightData
    {
        string AirlineId { get; set; }
        string ConnectId { get; set; }
        IDate Flightdate { get; }
        string Planetype { get; set; }
        string CurrencyIso { get; set; }
        decimal Price { get; set; }
    }
}
