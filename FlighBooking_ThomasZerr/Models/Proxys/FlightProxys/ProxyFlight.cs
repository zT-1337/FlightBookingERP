using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.SearchDatas;

namespace FlighBooking_ThomasZerr.Models.Proxys.FlightProxys
{
    abstract class ProxyFlight : Proxy
    {
        public abstract IFlightData[] GetList(IFlightData args, ISearchData searchData);
    }
}
