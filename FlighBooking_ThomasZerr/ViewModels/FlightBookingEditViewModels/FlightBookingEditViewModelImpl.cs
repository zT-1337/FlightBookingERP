using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Validators;
using FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators;
using FlighBooking_ThomasZerr.Models.Validators.MaxResultsValidators;
using FlighBooking_ThomasZerr.Models.Validators.TravelAgencyIdValidators;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    class FlightBookingEditViewModelImpl : NotifyPropertyChanged, IFlightBookingEditViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

        private IAirlineIdValidator airlinedIdValidator_;
        private ITravelAgencyIdValidator travelAgencyIdValidator_;
        private ICustomerIdValidator customerIdValidator_;
        private IDateRangeValidator dateRangeValidator_;
        private IMaxResultsValidator maxResultsValidator_;

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
            IFlightBookingData defaultArgs, ObservableCollection<IFlightBooking> retrievedFlightBookings,
            IOperationResultFactory operationResultFactory, 
            IAirlineIdValidator airlinedIdValidator, ITravelAgencyIdValidator travelAgencyIdValidator, ICustomerIdValidator customerIdValidator,
            IDateRangeValidator dateRangeValidator, IMaxResultsValidator maxResultsValidator)
        {
            flightBookingFactory_ = flightBookingFactory;
            Args = defaultArgs;
            RetrievedFlightBookings = retrievedFlightBookings;
            operationResultFactory_ = operationResultFactory;

            airlinedIdValidator_ = airlinedIdValidator;
            travelAgencyIdValidator_ = travelAgencyIdValidator;
            customerIdValidator_ = customerIdValidator;
            dateRangeValidator_ = dateRangeValidator;
            maxResultsValidator_ = maxResultsValidator;
        }

        public void DoFlightBookingSearch()
        {
            try
            {
                ValidateSearchInput();
                ExecuteFlightBookingSearch();
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
            ValidateTravelAgencyId();
            ValidateCustomerId();
            ValidateBookingDateRange();
            ValidateFlightDateRange();
            ValidateMaxResults();
        }

        private void ValidateAirlineId()
        {
            airlinedIdValidator_.IsValidElseThrowException(Args.FlightData.AirlineId);
        }

        private void ValidateTravelAgencyId()
        {
            travelAgencyIdValidator_.IsValidElseThrowException(Args.AgencyId);
        }

        private void ValidateCustomerId()
        {
            customerIdValidator_.IsValidElseThrowException(Args.CustomerId);
        }

        private void ValidateBookingDateRange()
        {
            dateRangeValidator_.LaterDateTime = Args.BookingDateRange.LaterDateTime;
            dateRangeValidator_.IsValidElseThrowException(Args.BookingDateRange.EarlierDateTime);
        }

        private void ValidateFlightDateRange()
        {
            dateRangeValidator_.LaterDateTime = Args.FlightDateRange.LaterDateTime;
            dateRangeValidator_.IsValidElseThrowException(Args.FlightDateRange.EarlierDateTime);
        }

        private void ValidateMaxResults()
        {
            maxResultsValidator_.IsValidElseThrowException(Args.MaxResults);
        }

        private void ExecuteFlightBookingSearch()
        {
            IFlightBooking[] flightBookings = flightBookingFactory_.Retrieve(Args);
            RetrievedFlightBookings.Clear();
            foreach (var flightBooking in flightBookings)
            {
                RetrievedFlightBookings.Add(flightBooking);
            }
        }

        public void DoConfirmFlightBooking()
        {
            try
            {
                ExecuteConfirmFlightBooking();
                OperationResult = operationResultFactory_.CreateSuccess();
            }
            catch (NullReferenceException e)
            {
                OperationResult = operationResultFactory_.CreateException(new Exception("Keine Flugbuchung ausgewählt"));
            }
            catch (Exception e)
            {
                OperationResult = operationResultFactory_.CreateException(e);
            }
        }

        private void ExecuteConfirmFlightBooking()
        {
            ChosenFlightBooking.Confirm();
        }

        public void DoCancelFlightBooking()
        {
            try
            {
                ExecuteCancelFlightBooking();
                OperationResult = operationResultFactory_.CreateSuccess();
            }
            catch (NullReferenceException e)
            {
                OperationResult = operationResultFactory_.CreateException(new Exception("Keine Flugbuchung ausgewählt"));
            }
            catch (Exception e)
            {
                OperationResult = operationResultFactory_.CreateException(e);
            }
        }

        private void ExecuteCancelFlightBooking()
        {
            ChosenFlightBooking.Cancel();
        }
    }
}
