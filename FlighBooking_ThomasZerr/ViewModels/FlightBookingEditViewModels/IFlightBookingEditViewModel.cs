using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    public interface IFlightBookingEditViewModel
    {
        IOperationResult OperationResult { get; }

        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        IFlightBookingData Args { get; }

        void DoFlightBookingSearch();
        void DoConfirmFlightBooking();
        void DoCancelFlightBooking();
    }
}
