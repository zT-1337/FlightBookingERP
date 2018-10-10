using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    interface IProxyERP
    {
        string Username { get; set; }
        string Password { set; }

        ProxyResponseERP FlightBookingConfirm(FlightBookingData args);
        ProxyResponseERP FlightBookingCancel(FlightBookingData args);
        ProxyResponseERP FlightBookingCreateFromData(FlightBookingData args);
        ProxyResponseERP FlightBookingGetList(FlightBookingData args);
    }
}
