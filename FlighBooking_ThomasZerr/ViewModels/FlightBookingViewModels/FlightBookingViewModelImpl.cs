using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas.Dates;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingViewModels
{
    class FlightBookingViewModelImpl
    {
        private IFlightBookingFactory flightBookingFactory_;

        public Exception CaughtException { get; private set; }
        public IFlightBooking ChosenFlightBooking { get; set; }
        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }
        public ObservableCollection<IFlightBooking> CreatedFlightBookings { get; }

        public IFlightBookingData Args { get; }

        public FlightBookingViewModelImpl(IFlightBookingData defaultArgs, IFlightBookingFactory flightBookingFactory, ObservableCollection<IFlightBooking> retrievedFlightBookings, 
                                            ObservableCollection<IFlightBooking> createdFlightBookings)
        {
            Args = defaultArgs;
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
                return flightBookingFactory_.RetrieveAll(Args);
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
                IFlightBooking flightBooking = flightBookingFactory_.Create(Args);
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
