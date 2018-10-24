using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    public interface IProxyFlightBooking
    {
        string Username { get; set; }
        string Password { set; }

        ProxyFlightBookingResponse FlightBookingConfirm(IFlightBookingData args);
        ProxyFlightBookingResponse FlightBookingCancel(IFlightBookingData args);
        ProxyFlightBookingResponse FlightBookingCreateFromData(IFlightBookingData args);
        ProxyFlightBookingResponse FlightBookingGetList(IFlightBookingData args);
    }
}
