using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Flights
{
    public interface IFlight
    {
        IFlightData FlightData { get; }
    }
}
