using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    interface IFlightBookingFactory
    {
        IFlightBooking Create(FlightBookingData args);
        IFlightBooking[] RetrieveAll(FlightBookingData args);
    }
}
