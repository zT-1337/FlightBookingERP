using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.SearchDatas;

namespace FlighBooking_ThomasZerr.Models.Flights.Factorys
{
    interface IFlightFactory
    {
        IFlight[] Retrieve(IFlightData data, ISearchData searchData);
    }
}
