using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys
{
    public interface IFlightBookingCreateWindowFactory
    {
        FlightBookingCreateWindow Create(string username, string password);
    }
}
