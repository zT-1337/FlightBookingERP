namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys
{
    public interface IFlightBookingWindowFactory
    {
        FlightBookingWindow Create(string username, string password);
    }
}
