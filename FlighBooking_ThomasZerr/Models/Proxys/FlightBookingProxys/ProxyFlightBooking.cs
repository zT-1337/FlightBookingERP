using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    abstract class ProxyFlightBooking : Proxy
    {
        public abstract void Confirm(IFlightBookingData args);
        public abstract void Cancel(IFlightBookingData args);
        public abstract IFlightBookingData Create(IFlightBookingData args);
        public abstract IFlightBookingData[] GetList(IFlightBookingData args);
    }
}
