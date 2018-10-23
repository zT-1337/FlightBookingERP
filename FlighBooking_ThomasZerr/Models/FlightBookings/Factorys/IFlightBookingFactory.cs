using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    public interface IFlightBookingFactory
    {
        IFlightBooking Create(IFlightBookingData args);
        IFlightBooking[] RetrieveAll(IFlightBookingData args);
    }
}
