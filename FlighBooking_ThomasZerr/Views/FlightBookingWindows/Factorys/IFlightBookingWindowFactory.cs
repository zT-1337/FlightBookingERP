namespace FlighBooking_ThomasZerr.Views.FlightBookingWindows.Factorys
{
    interface IFlightBookingWindowFactory
    {
        FlightBookingWindow Create(string username, string password);
    }
}
