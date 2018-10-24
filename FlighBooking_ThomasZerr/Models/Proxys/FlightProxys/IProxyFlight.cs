using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    interface IProxyFlight
    {
        string Username { get; set; }
        string Password { set; }

        ProxyFlightResponse IsExisting(IFlightData args);
        ProxyFlightResponse Create(IFlightData args);
    }
}
