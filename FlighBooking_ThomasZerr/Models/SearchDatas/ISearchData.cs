using FlighBooking_ThomasZerr.Models.DateRanges;

namespace FlighBooking_ThomasZerr.Models.SearchDatas
{
    public interface ISearchData
    {
        IDateRange FlightDateRange { get; }
        IDateRange BookingDateRange { get; }
        int MaxResults { get; set; }
        bool IsMaxResultsActive { get; set; }
    }
}