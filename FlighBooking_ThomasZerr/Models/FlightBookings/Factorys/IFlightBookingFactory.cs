using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    interface IFlightBookingFactory
    {
        IFlightBooking Create(FlightBookingData args);
        IFlightBooking[] RetrieveAll(FlightBookingData args);
    }
}
