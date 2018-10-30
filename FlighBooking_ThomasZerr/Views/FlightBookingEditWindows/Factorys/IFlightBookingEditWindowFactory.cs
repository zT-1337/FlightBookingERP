using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    public interface IFlightBookingEditWindowFactory
    {
        string Username { get; set; }
        string Password { get; set; }

        FlightBookingEditWindow Create();
    }
}
