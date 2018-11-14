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
using FlighBooking_ThomasZerr.Models.OperationResult;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Validators;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    class FlightBookingCreateViewModelImpl : NotifyPropertyChanged, IFlightBookingCreateViewModel
    {
        private IFlightFactory flightFactory_;
        private IFlightBookingFactory flightBookingFactory_;

        private IValidator airlineIdValidator_;
        private IValidator flightDateRangeValidator_;
        private IValidator maxResultsDateValidator_;

        private IValidator travelAgencyIdValidator_;
        private IValidator customerIdValidator_;
        private IValidator flightClassValidator_;

        private IOperationResultFactory operationResultFactory_;
        private IOperationResult operationResult_;
        public IOperationResult OperationResult
        {
            get => operationResult_;
            private set
            {
                operationResult_ = value;
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
            ObservableCollection<IFlight> retrievedFlights, IOperationResultFactory operationResultFactory,
            IValidator airlineIdValidator, IValidator flightDateRangeValidator, IValidator maxResultsDateValidator,
            IValidator travelAgencyIdValidator, IValidator customerIdValidator, IValidator flightClassValidator)
        {
            flightFactory_ = flightFactory;
            FlightArgs = defaultFlightArgs;

            flightBookingFactory_ = flightBookingFactory;
            FlightBookingArgs = defaultFlightBookingArgs;

            RetrievedFlights = retrievedFlights;

            operationResultFactory_ = operationResultFactory;

            airlineIdValidator_ = airlineIdValidator;
            flightDateRangeValidator_ = flightDateRangeValidator;
            maxResultsDateValidator_ = maxResultsDateValidator;

            travelAgencyIdValidator_ = travelAgencyIdValidator;
            customerIdValidator_ = customerIdValidator;
            flightClassValidator_ = flightClassValidator;
        }

        public void DoFlightSearch()
        {
            try
            {
                ValidateSearchInput();
                ExecuteFlightSearch();
                OperationResult = operationResultFactory_.CreateSuccess();
            }
            catch (Exception e)
            {
                OperationResult = operationResultFactory_.CreateException(e);
            }
        }

        private void ValidateSearchInput()
        {
            ValidateAirlineId();
            ValidateFlightDateRange();
            ValidateMaxResults();
        }

        private void ValidateAirlineId()
        {
            airlineIdValidator_.IsValidElseThrowException(FlightArgs.AirlineId);
        }

        private void ValidateFlightDateRange()
        {
            flightDateRangeValidator_.ExtraParam = FlightArgs.FlightDateRange.LaterDateTime;
            flightDateRangeValidator_.IsValidElseThrowException(FlightArgs.FlightDateRange.EarlierDateTime);
        }

        private void ValidateMaxResults()
        {
            maxResultsDateValidator_.IsValidElseThrowException(FlightArgs.MaxResults);
        }

        private void ExecuteFlightSearch()
        {
            IFlight[] flights = flightFactory_.Retrieve(FlightArgs);
            RetrievedFlights.Clear();
            foreach (var flight in flights)
            {
                RetrievedFlights.Add(flight);
            }
        }

        public void DoCreateFlightBooking()
        {
            try
            {
                ValidateCreateInput();
                ExecuteCreateFlightBooking();
                OperationResult = operationResultFactory_.CreateSuccess();
            }
            catch (NullReferenceException e)
            {
                OperationResult = operationResultFactory_.CreateException(new Exception("Kein Flug ausgewählt"));
            }
            catch (Exception e)
            {
                OperationResult = operationResultFactory_.CreateException(e);
            }
        }

        private void ValidateCreateInput()
        {
            ValidateTravelAgencyId();
            ValidateCustomerId();
            ValidateClass();
        }

        private void ValidateTravelAgencyId()
        {
            travelAgencyIdValidator_.IsValidElseThrowException(FlightBookingArgs.AgencyId);
        }

        private void ValidateCustomerId()
        {
            customerIdValidator_.IsValidElseThrowException(FlightBookingArgs.CustomerId);
        }

        private void ValidateClass()
        {
            flightClassValidator_.IsValidElseThrowException(FlightBookingArgs.Class);
        }

        private void ExecuteCreateFlightBooking()
        {
            UpdateFlightDataOfFlightBookingArgs();
            flightBookingFactory_.Create(FlightBookingArgs);
        }

        private void UpdateFlightDataOfFlightBookingArgs()
        {
            FlightBookingArgs.FlightData.AirlineId = ChosenFlight.FlightData.AirlineId;
            FlightBookingArgs.FlightData.ConnectId = ChosenFlight.FlightData.ConnectId;
            FlightBookingArgs.FlightData.Flightdate.DateString = ChosenFlight.FlightData.Flightdate.DateString;
        }
    }
}
