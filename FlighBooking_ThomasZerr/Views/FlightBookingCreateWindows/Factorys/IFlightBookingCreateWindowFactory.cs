using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys
{
    public interface IFlightBookingCreateWindowFactory
    {
        string Username { get; set; }
        string Password { get; set; }

        FlightBookingCreateWindow Create();
    }
}
