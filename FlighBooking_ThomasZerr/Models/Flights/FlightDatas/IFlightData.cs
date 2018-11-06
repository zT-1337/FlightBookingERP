using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Dates;

namespace FlighBooking_ThomasZerr.Models.Flights.FlightDatas
{
    public interface IFlightData
    {
        string AirlineId { get; set; }
        string ConnectId { get; set; }
        IDate Flightdate { get; }
        IDateRange FlightDateRange { get; }
        string Planetype { get; set; }
        string CurrencyIso { get; set; }
        decimal Price { get; set; }
        int MaxResults { get; set; }
        bool IsMaxResultsActive { get; set; }
    }
}
