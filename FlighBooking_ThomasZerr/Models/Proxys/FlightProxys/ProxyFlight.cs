using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    abstract class ProxyFlight : Proxy
    {
        public abstract IFlightData[] GetList(IFlightData args, IDateRange flightDateRangeArg, int maxResultsArg, bool isMaxResultActive);
    }
}
