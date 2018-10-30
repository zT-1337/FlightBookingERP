using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    public interface IFlightBookingEditWindowFactory
    {
        FlightBookingEditWindow Create(string username, string password);
    }
}
