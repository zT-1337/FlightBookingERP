using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    interface IProxyERP
    {
        string Username { get; set; }
        string Password { set; }

        ProxyResponseERP FlightBookingConfirm(IFlightBookingData args);
        ProxyResponseERP FlightBookingCancel(IFlightBookingData args);
        ProxyResponseERP FlightBookingCreateFromData(IFlightBookingData args);
        ProxyResponseERP FlightBookingGetList(IFlightBookingData args);
    }
}
