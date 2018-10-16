using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    interface IFlightBooking
    {
        FlightBookingData FlightBookingData { get; set; }

        void Confirm();
        void Cancel();
    }
}
