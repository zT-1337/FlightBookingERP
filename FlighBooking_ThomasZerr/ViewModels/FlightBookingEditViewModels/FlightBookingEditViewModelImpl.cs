using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
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
        private readonly IFlightBookingFactory flightBookingFactory_;

        private readonly IAirlineIdValidator airlinedIdValidator_;
        private readonly ITravelAgencyIdValidator travelAgencyIdValidator_;
        private readonly ICustomerIdValidator customerIdValidator_;
        private readonly IDateRangeValidator dateRangeValidator_;
        private readonly IMaxResultsValidator maxResultsValidator_;

        private readonly IOperationResultFactory operationResultFactory_;
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
        public IDateRange BookingDateRange { get; }
        public IDateRange FlightDateRange { get; }
        public int MaxResults { get; set; }
        public bool IsMaxResultsActive { get; set; }


        public FlightBookingEditViewModelImpl(IFlightBookingFactory flightBookingFactory,
            IFlightBookingData defaultArgs, IDateRange bookingDateRange, IDateRange flightDateRange,
            ObservableCollection<IFlightBooking> retrievedFlightBookings,
            IOperationResultFactory operationResultFactory, 
            IAirlineIdValidator airlinedIdValidator, ITravelAgencyIdValidator travelAgencyIdValidator, ICustomerIdValidator customerIdValidator,
            IDateRangeValidator dateRangeValidator, IMaxResultsValidator maxResultsValidator)
        {
            flightBookingFactory_ = flightBookingFactory;
            Args = defaultArgs;
            BookingDateRange = bookingDateRange;
            FlightDateRange = flightDateRange;
            MaxResults = 0;
            IsMaxResultsActive = false;

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
            dateRangeValidator_.LaterDateTime = BookingDateRange.LaterDateTime;
            dateRangeValidator_.IsValidElseThrowException(BookingDateRange.EarlierDateTime);
        }

        private void ValidateFlightDateRange()
        {
            dateRangeValidator_.LaterDateTime = FlightDateRange.LaterDateTime;
            dateRangeValidator_.IsValidElseThrowException(FlightDateRange.EarlierDateTime);
        }

        private void ValidateMaxResults()
        {
            maxResultsValidator_.IsValidElseThrowException(MaxResults);
        }

        private void ExecuteFlightBookingSearch()
        {
            IFlightBooking[] flightBookings = flightBookingFactory_.Retrieve(Args, BookingDateRange, FlightDateRange, MaxResults, IsMaxResultsActive);
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
