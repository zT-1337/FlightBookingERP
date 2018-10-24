using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys
{
    public interface IProxyFlightBooking
    {
        string Username { get; set; }
        string Password { set; }

        ProxyResponse FlightBookingConfirm(IFlightBookingData args);
        ProxyResponse FlightBookingCancel(IFlightBookingData args);
        ProxyResponse FlightBookingCreateFromData(IFlightBookingData args);
        ProxyResponse FlightBookingGetList(IFlightBookingData args);
    }
}
