using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.SearchDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings.Factorys
{
    public interface IFlightBookingFactory
    {
        IFlightBooking Create(IFlightBookingData args);
        IFlightBooking[] Retrieve(IFlightBookingData args, ISearchData searchData);
    }
}
