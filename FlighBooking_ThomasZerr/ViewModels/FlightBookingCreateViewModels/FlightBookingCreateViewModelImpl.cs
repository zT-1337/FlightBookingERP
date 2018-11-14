using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.OperationResult;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Validators;
using FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators;
using FlighBooking_ThomasZerr.Models.Validators.FlightClassValidators;
using FlighBooking_ThomasZerr.Models.Validators.MaxResultsValidators;
using FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidators;
using FlighBooking_ThomasZerr.Models.Validators.TravelAgencyIdValidators;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    class FlightBookingCreateViewModelImpl : NotifyPropertyChanged, IFlightBookingCreateViewModel
    {
        private IFlightFactory flightFactory_;
        private IFlightBookingFactory flightBookingFactory_;

        private IAirlineIdValidator airlineIdValidator_;
        private IDateRangeValidator flightDateRangeValidator_;
        private IMaxResultsValidator maxResultsDateValidator_;
        private ITravelAgencyIdValidator travelAgencyIdValidator_;
        private ICustomerIdValidator customerIdValidator_;
        private IFlightClassValidator flightClassValidator_;
        private INotEmptyStringValidator notEmptyStringValidator_;

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
        public IDateRange FlightDateRange { get; }
        public int MaxResults { get; set; }
        public bool IsMaxResultsActive { get; set; }

        public IFlightBookingData FlightBookingArgs { get; }

        public FlightBookingCreateViewModelImpl(IFlightFactory flightFactory, IFlightData defaultFlightArgs, IDateRange flightDateRange,
            IFlightBookingFactory flightBookingFactory, IFlightBookingData defaultFlightBookingArgs,
            ObservableCollection<IFlight> retrievedFlights, IOperationResultFactory operationResultFactory,
            IAirlineIdValidator airlineIdValidator, IDateRangeValidator flightDateRangeValidator, IMaxResultsValidator maxResultsDateValidator,
            ITravelAgencyIdValidator travelAgencyIdValidator, ICustomerIdValidator customerIdValidator, IFlightClassValidator flightClassValidator,
            INotEmptyStringValidator notEmptyStringValidator)
        {
            flightFactory_ = flightFactory;
            FlightArgs = defaultFlightArgs;
            FlightDateRange = flightDateRange;
            MaxResults = 0;
            IsMaxResultsActive = false;

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

            notEmptyStringValidator_ = notEmptyStringValidator;
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
            flightDateRangeValidator_.LaterDateTime = FlightDateRange.LaterDateTime;
            flightDateRangeValidator_.IsValidElseThrowException(FlightDateRange.EarlierDateTime);
        }

        private void ValidateMaxResults()
        {
            maxResultsDateValidator_.IsValidElseThrowException(MaxResults);
        }

        private void ExecuteFlightSearch()
        {
            IFlight[] flights = flightFactory_.Retrieve(FlightArgs, FlightDateRange, MaxResults, IsMaxResultsActive);
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
            notEmptyStringValidator_.PropertyName = "Reisebüro";
            notEmptyStringValidator_.IsValidElseThrowException(FlightBookingArgs.AgencyId);

            travelAgencyIdValidator_.IsValidElseThrowException(FlightBookingArgs.AgencyId);
        }

        private void ValidateCustomerId()
        {
            notEmptyStringValidator_.PropertyName = "Kundennummer";
            notEmptyStringValidator_.IsValidElseThrowException(FlightBookingArgs.CustomerId);

            customerIdValidator_.IsValidElseThrowException(FlightBookingArgs.CustomerId);
        }

        private void ValidateClass()
        {
            notEmptyStringValidator_.PropertyName = "Klasse";
            notEmptyStringValidator_.IsValidElseThrowException(FlightBookingArgs.Class);

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
