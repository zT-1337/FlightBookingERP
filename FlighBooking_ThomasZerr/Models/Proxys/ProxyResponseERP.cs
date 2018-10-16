using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys
{
    class ProxyResponseERP
    {
        public FlightBookingData FlightBookingData { get; set; }
        public ReturnCodeERP ReturnCode { get; set; }
    }
}
