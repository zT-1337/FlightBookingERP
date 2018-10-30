namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys
{
    public interface IFlightBookingWindowFactory
    {
        FlightBookingMainWindow Create(string username, string password);
    }
}
