using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    interface IFlightBookingFactory
    {
        IFlightBooking Create(FlightBookingData args);
        IFlightBooking[] RetrieveAll(FlightBookingData args);
    }
}
