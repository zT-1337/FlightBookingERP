using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.SearchDatas;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    class FlightBookingEditViewModelImpl : NotifyPropertyChanged, IFlightBookingEditViewModel
    {
        private readonly IFlightBookingFactory flightBookingFactory_;

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

        public ObservableCollection<IFlightBooking> RetrievedFlightBookings { get; set; }

        private IFlightBookingData args_;
        public string AirlineId
        {
            get => args_.FlightData.AirlineId;
            set
            {
                try
                {
                    args_.FlightData.AirlineId = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public string TravelAgencyId
        {
            get => args_.AgencyId;
            set
            {
                try
                {
                    args_.AgencyId = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public string CustomerId
        {
            get => args_.CustomerId;
            set
            {
                try
                {
                    args_.CustomerId = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }

        private ISearchData searchData_;
        public DateRangeOption BookingDateRangeOption
        {
            get => searchData_.BookingDateRange.Option;
            set
            {
                try
                {
                    searchData_.BookingDateRange.Option = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public DateTime BookingDateEarlierDateTime
        {
            get => searchData_.BookingDateRange.EarlierDateTime;
            set
            {
                try
                {
                    searchData_.BookingDateRange.EarlierDateTime = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public DateTime BookingDateLaterDateTime
        {
            get => searchData_.BookingDateRange.LaterDateTime;
            set
            {
                try
                {
                    searchData_.BookingDateRange.LaterDateTime = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public DateRangeOption FlightDateRangeOption
        {
            get => searchData_.FlightDateRange.Option;
            set
            {
                try
                {
                    searchData_.FlightDateRange.Option = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public DateTime FlightDateEarlierDateTime
        {
            get => searchData_.FlightDateRange.EarlierDateTime;
            set
            {
                try
                {
                    searchData_.FlightDateRange.EarlierDateTime = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public DateTime FlightDateLaterDateTime
        {
            get => searchData_.FlightDateRange.LaterDateTime;
            set
            {
                try
                {
                    searchData_.FlightDateRange.LaterDateTime = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public int MaxResults
        {
            get => searchData_.MaxResults;
            set
            {
                try
                {
                    searchData_.MaxResults = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public bool IsMaxResultsActive
        {
            get => searchData_.IsMaxResultsActive;
            set
            {
                try
                {
                    searchData_.IsMaxResultsActive = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }

        public FlightBookingEditViewModelImpl(IFlightBookingFactory flightBookingFactory,
                                              IFlightBookingData defaultArgs, ISearchData searchData,
                                              IOperationResultFactory operationResultFactory)
        {
            flightBookingFactory_ = flightBookingFactory;
            args_ = defaultArgs;
            searchData_ = searchData;

            operationResultFactory_ = operationResultFactory;
        }

        public void DoFlightBookingSearch()
        {
            try
            {
                ExecuteFlightBookingSearch();
                OperationResult = operationResultFactory_.CreateSuccess();
            }
            catch (Exception e)
            {
                OperationResult = operationResultFactory_.CreateException(e);
            }
        }

        private void ExecuteFlightBookingSearch()
        {
            IFlightBooking[] flightBookings = flightBookingFactory_.Retrieve(args_, searchData_);
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
