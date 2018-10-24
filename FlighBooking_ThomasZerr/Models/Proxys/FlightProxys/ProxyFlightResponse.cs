using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    class ProxyFlightResponse
    {
        public ReturnCodeProxys ReturnCode { get; set; }
        public string Message { get; set; }
    }
}
