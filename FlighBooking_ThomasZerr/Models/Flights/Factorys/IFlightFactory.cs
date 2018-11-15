using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Flights.Factorys
{
    interface IFlightFactory
    {
        IFlight[] Retrieve(IFlightData data, IDateRange flightDateRangeArg, int maxResultsArg, bool isMaxResultActive);
    }
}
