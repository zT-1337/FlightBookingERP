namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows.Factorys
{
    public interface IFlightBookingWindowFactory
    {
        FlightBookingWindow Create(string username, string password);
    }
}
