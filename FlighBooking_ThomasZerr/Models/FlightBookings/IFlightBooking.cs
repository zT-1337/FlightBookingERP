using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    interface IFlightBooking
    {
        FlightBookingData FlightBookingData { get; set; }

        void Confirm();
        void Cancel();
    }
}
