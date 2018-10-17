using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    class FlightBookingViewModelImpl : IFlightBookingViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

        public IFlightBooking ChosenFlightBooking { get; private set; }
        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        private FlightBookingData args_;
        public string AirlineName
        {
            get => args_.AirlineName;
            set { args_.AirlineName = value; } 
        }
        public string TravelAgency
        {
            get => args_.TravelAgency;
            set => args_.TravelAgency = value;
        }
        public string CustomerId
        {
            get => args_.CustomerId;
            set => args_.CustomerId = value;
        }
        public IDateRange BookingDateRange => args_.BookingDateRange;
        public IDateRange FlightDateRange => args_.FlightDateRange;

        public FlightBookingViewModelImpl(FlightBookingData defaultArgs, IFlightBookingFactory flightBookingFactory, ObservableCollection<IFlightBooking> retrievedFlightBookings)
        {
            args_ = defaultArgs;
            flightBookingFactory_ = flightBookingFactory;
            RetrievedFlightBookings = retrievedFlightBookings;
        }

        public void DoFlightBookingSearch()
        {
            //TODO Exceptionhandling
            IFlightBooking[] flightBookings = flightBookingFactory_.RetrieveAll(args_);
            foreach (var flightBooking in flightBookings)
            {
                RetrievedFlightBookings.Add(flightBooking);
            }
        }

        public void DoChooseFlightBooking(int index)
        {
            ChosenFlightBooking = RetrievedFlightBookings[index];
        }

        public void DoCreateFlightBooking()
        {
            throw new NotImplementedException();
        }

        public void DoConfirmFlightBooking()
        {
            throw new NotImplementedException();
        }

        public void DoCancelFlightBooking()
        {
            throw new NotImplementedException();
        }
    }
}
