﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows.Factorys
{
    interface IFlightBookingWindowFactory
    {
        FlightBookingWindow Create(string username, string password);
    }
}