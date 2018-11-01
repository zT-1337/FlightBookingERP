using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    class FlightBookingCreateViewModelImpl : NotifyPropertyChanged, IFlightBookingCreateViewModel
    {
        private IFlightFactory flightFactory_;
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

        private IFlight chosenFlight_;
        public IFlight ChosenFlight
        {
            get => chosenFlight_;
            set
            {
                chosenFlight_ = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<IFlight> RetrievedFlights { get; }

        public IFlightData FlightArgs { get; }
        public IFlightBookingData FlightBookingArgs { get; }

        public FlightBookingCreateViewModelImpl(IFlightFactory flightFactory, IFlightData defaultFlightArgs, 
            IFlightBookingFactory flightBookingFactory, IFlightBookingData defaultFlightBookingArgs,
            ObservableCollection<IFlight> retrievedFlights)
        {
            flightFactory_ = flightFactory;
            FlightArgs = defaultFlightArgs;

            flightBookingFactory_ = flightBookingFactory;
            FlightBookingArgs = defaultFlightBookingArgs;

            RetrievedFlights = retrievedFlights;
        }

        public void DoFlightSearch()
        {
            try
            {
                IFlight[] flights = flightFactory_.Retrieve(FlightArgs);
                RetrievedFlights.Clear();
                foreach (var flight in flights)
                {
                    RetrievedFlights.Add(flight);
                }

                CaughtException = null;
            }
            catch (Exception e)
            {
                CaughtException = e;
            }
        }

        public void DoCreateFlightBooking()
        {
            UpdateFlightDataOfFlightBookingArgs();

            try
            { 
                flightBookingFactory_.Create(FlightBookingArgs);
                CaughtException = null;
            }
            catch (Exception e)
            {
                CaughtException = e;
            }
        }

        private void UpdateFlightDataOfFlightBookingArgs()
        {
            FlightBookingArgs.FlightData.AirlineId = ChosenFlight.FlightData.AirlineId;
            FlightBookingArgs.FlightData.ConnectId = ChosenFlight.FlightData.ConnectId;
            FlightBookingArgs.FlightData.Flightdate.DateString = ChosenFlight.FlightData.Flightdate.DateString;
        }
    }
}
