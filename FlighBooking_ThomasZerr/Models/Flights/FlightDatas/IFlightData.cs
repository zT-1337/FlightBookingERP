using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates;

namespace FlighBooking_ThomasZerr.Models.Flights.FlightDatas
{
    public interface IFlightData
    {
        string AirlineId { get; set; }
        string ConnectId { get; set; }
        IDate Flightdate { get; }
        string Planetype { get; set; }
        string CurrencyIso { get; set; }
    }
}
