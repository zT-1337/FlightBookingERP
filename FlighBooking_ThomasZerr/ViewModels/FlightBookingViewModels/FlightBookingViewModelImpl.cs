using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    class FlightBookingViewModelImpl : IFlightBookingViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

        public Exception CaughtException { get; private set; }
        public IFlightBooking ChosenFlightBooking { get; set; }
        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }
        public ObservableCollection<IFlightBooking> CreatedFlightBookings { get; }

        private IFlightBookingData args_;
        public string CustomerId
        {
            get => args_.CustomerId;
            set => args_.CustomerId = value;
        }
        public IDateRange BookingDateRange => args_.BookingDateRange;
        public IDateRange FlightDateRange => args_.FlightDateRange;
        public string AgencyId
        {
            get => args_.AgencyId;
            set => args_.AgencyId = value ; 
        }
        public string AirlineId
        {
            get => args_.AirlineId;
            set => args_.AirlineId = value;
        }
        public string Class
        {
            get => args_.Class;
            set => args_.Class = value;
        }
        public string ConnectId
        {
            get => args_.ConnectId;
            set => args_.ConnectId = value;
        }
        public string Counter
        {
            get => args_.Counter;
            set => args_.Counter = value;
        }
        public string Flightdate
        {
            get => args_.Flightdate;
            set => args_.Flightdate = value;
        }
        public string PassagierName
        {
            get => args_.PassagierName;
            set => args_.PassagierName = value;
        }
        public bool Reserved
        {
            get => args_.Reserved;
            set => args_.Reserved = value;
        }

        public FlightBookingViewModelImpl(IFlightBookingData defaultArgs, IFlightBookingFactory flightBookingFactory, ObservableCollection<IFlightBooking> retrievedFlightBookings, 
                                            ObservableCollection<IFlightBooking> createdFlightBookings)
        {
            args_ = defaultArgs;
            flightBookingFactory_ = flightBookingFactory;
            RetrievedFlightBookings = retrievedFlightBookings;
            CreatedFlightBookings = createdFlightBookings;
        }

        public void DoFlightBookingSearch()
        {
            IFlightBooking[] flightBookings = RetrieveFlightBookings();
            RetrievedFlightBookings.Clear();
            foreach (var flightBooking in flightBookings)
            {
                RetrievedFlightBookings.Add(flightBooking);
            }
        }

        private IFlightBooking[] RetrieveFlightBookings()
        {
            try
            {
                return flightBookingFactory_.RetrieveAll(args_);
            }
            catch (Exception e)
            {
                CaughtException = e;
            }

            return new IFlightBooking[0];
        }

        public void DoCreateFlightBooking()
        {
            try
            {
                IFlightBooking flightBooking = flightBookingFactory_.Create(args_);
                CreatedFlightBookings.Add(flightBooking);
            }
            catch (Exception e)
            {
                CaughtException = e;
            }   
        }

        public void DoConfirmFlightBooking()
        {
            try
            {
                ChosenFlightBooking.Confirm();
            }
            catch (Exception e)
            {
                CaughtException = e;
            }
        }

        public void DoCancelFlightBooking()
        {
            try
            {
                ChosenFlightBooking.Cancel();
            }
            catch (Exception e)
            {
                CaughtException = e;
            }            
        }
    }
}
