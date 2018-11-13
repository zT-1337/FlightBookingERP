using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    abstract class ProxyFlightBooking : Proxy
    {
        public abstract ProxyFlightBookingResponse Confirm(IFlightBookingData args);
        public abstract ProxyFlightBookingResponse Cancel(IFlightBookingData args);
        public abstract ProxyFlightBookingResponse Create(IFlightBookingData args);
        public abstract ProxyFlightBookingResponse GetList(IFlightBookingData args);
    }
}
