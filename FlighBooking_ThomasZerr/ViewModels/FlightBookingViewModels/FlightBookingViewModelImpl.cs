using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    class FlightBookingViewModelImpl : IFlightBookingViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

        public IFlightBooking ChosenFlightBooking { get; }
        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        public string AirlineName { get; set; }
        public string TravelAgency { get; set; }
        public string CustomerNumber { get; set; }
        public IDateRange BookingDateRange { get; }
        public IDateRange FlightDateRange { get; }

        public void DoFlightBookingSearch()
        {
            throw new NotImplementedException();
        }
    }
}
