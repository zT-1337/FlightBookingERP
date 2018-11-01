using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    class FlightBookingEditViewModelImpl : NotifyPropertyChanged, IFlightBookingEditViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

        private Exception caughtException_;
        public Exception CaughtException
        {
            get => caughtException_;
            private set
            {
                caughtException_ = value;
                RaisePropertyChanged();
            }
        }

        private IFlightBooking chosenFlightBooking_;
        public IFlightBooking ChosenFlightBooking
        {
            get => chosenFlightBooking_;
            set
            {
                chosenFlightBooking_ = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; }

        public IFlightBookingData Args { get; }

        public FlightBookingEditViewModelImpl(IFlightBookingFactory flightBookingFactory,
            IFlightBookingData defaultArgs, ObservableCollection<IFlightBooking> retrievedFlightBookings)
        {
            flightBookingFactory_ = flightBookingFactory;
            Args = defaultArgs;
            RetrievedFlightBookings = retrievedFlightBookings;
        }

        public void DoFlightBookingSearch()
        {
            try
            {
                IFlightBooking[] flightBookings = flightBookingFactory_.Retrieve(Args);
                RetrievedFlightBookings.Clear();
                foreach (var flightBooking in flightBookings)
                {
                    RetrievedFlightBookings.Add(flightBooking);
                }
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
