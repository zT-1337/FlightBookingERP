using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    interface IFlightBookingViewModel
    {
        IFlightBooking ChosenFlightBooking { get; set; }
        ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }
    }
}
