using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    public interface IProxyFlightBooking
    {
        string Username { get; set; }
        string Password { set; }

        ProxyFlightBookingResponse Confirm(IFlightBookingData args);
        ProxyFlightBookingResponse Cancel(IFlightBookingData args);
        ProxyFlightBookingResponse Create(IFlightBookingData args);
        ProxyFlightBookingResponse GetList(IFlightBookingData args);
    }
}
