
namespace FlighBooking_ThomasZerr.Views.FlightBookingCreateWindows.Factorys
{
    public interface IFlightBookingCreateWindowFactory
    {
        string Username { get; set; }
        string Password { get; set; }

        FlightBookingCreateWindow Create();
    }
}
