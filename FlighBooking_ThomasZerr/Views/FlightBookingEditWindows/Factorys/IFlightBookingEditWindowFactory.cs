
namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    public interface IFlightBookingEditWindowFactory
    {
        string Username { get; set; }
        string Password { get; set; }

        FlightBookingEditWindow Create();
    }
}
