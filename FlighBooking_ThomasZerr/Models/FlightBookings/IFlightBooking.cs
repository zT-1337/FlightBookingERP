using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;

namespace FlighBooking_ThomasZerr.Models.FlightBookings
{
    public interface IFlightBooking
    {
        IFlightBookingData FlightBookingData { get; }

        void Confirm();
        void Cancel();
    }
}
