namespace FlighBooking_ThomasZerr.Views.FlightBookingMainWindows.Factorys
{
    public interface IFlightBookingMainWindowFactory
    {
        FlightBookingMainWindow Create(string username, string password);
    }
}
