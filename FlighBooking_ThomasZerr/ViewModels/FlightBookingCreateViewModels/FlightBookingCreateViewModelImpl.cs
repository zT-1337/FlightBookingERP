using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.DateRanges;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.Flights;
using FlighBooking_ThomasZerr.Models.Flights.Factorys;
using FlighBooking_ThomasZerr.Models.Flights.FlightDatas;
using FlighBooking_ThomasZerr.Models.OperationResults;
using FlighBooking_ThomasZerr.Models.OperationResults.Factorys;
using FlighBooking_ThomasZerr.Models.SearchDatas;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingCreateViewModels
{
    class FlightBookingCreateViewModelImpl : NotifyPropertyChanged, IFlightBookingCreateViewModel
    {
        private readonly IFlightFactory flightFactory_;
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

        public ObservableCollection<IFlight> RetrievedFlights { get; set; }

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

        private IFlightData flightArgs_;
        public string AirlineIdForSearch
        {
            get => flightArgs_.AirlineId;
            set
            {
                try
                {
                    flightArgs_.AirlineId = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }

        private ISearchData searchData_;
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

        private IFlightBookingData flightBookingArgs_;
        public string AirlineIdForCreate
        {
            get => flightBookingArgs_.FlightData.AirlineId;
            set
            {
                try
                {
                    flightBookingArgs_.FlightData.AirlineId = value;
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
            get => flightBookingArgs_.AgencyId;
            set
            {
                try
                {
                    flightBookingArgs_.AgencyId = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public string FlightClass
        {
            get => flightBookingArgs_.Class;
            set
            {
                try
                {
                    flightBookingArgs_.Class = value;
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
            get => flightBookingArgs_.CustomerId;
            set
            {
                try
                {
                    flightBookingArgs_.CustomerId = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public string PassagierName
        {
            get => flightBookingArgs_.PassagierName;
            set
            {
                try
                {
                    flightBookingArgs_.PassagierName = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }
        public bool IsReserved
        {
            get => flightBookingArgs_.Reserved;
            set
            {
                try
                {
                    flightBookingArgs_.Reserved = value;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    OperationResult = operationResultFactory_.CreateException(e);
                }
            }
        }

        public FlightBookingCreateViewModelImpl(IFlightFactory flightFactory, IFlightData defaultFlightArgs,
                                                IFlightBookingFactory flightBookingFactory, IFlightBookingData defaultFlightBookingArgs,
                                                ISearchData searchData, IOperationResultFactory operationResultFactory)
        {
            flightFactory_ = flightFactory;
            flightArgs_ = defaultFlightArgs;

            flightBookingFactory_ = flightBookingFactory;
            flightBookingArgs_ = defaultFlightBookingArgs;

            searchData_ = searchData;

            operationResultFactory_ = operationResultFactory;
        }

        public void DoFlightSearch()
        {
            try
            {
                ExecuteFlightSearch();
                OperationResult = operationResultFactory_.CreateSuccess();
            }
            catch (Exception e)
            {
                OperationResult = operationResultFactory_.CreateException(e);
            }
        }

        private void ExecuteFlightSearch()
        {
            IFlight[] flights = flightFactory_.Retrieve(flightArgs_, searchData_);
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

        private void ExecuteCreateFlightBooking()
        {
            UpdateFlightDataOfFlightBookingArgs();
            flightBookingFactory_.Create(flightBookingArgs_);
        }

        private void UpdateFlightDataOfFlightBookingArgs()
        {
            flightBookingArgs_.FlightData.AirlineId = ChosenFlight.FlightData.AirlineId;
            flightBookingArgs_.FlightData.ConnectId = ChosenFlight.FlightData.ConnectId;
            flightBookingArgs_.FlightData.Flightdate.DateString = ChosenFlight.FlightData.Flightdate.DateString;
        }
    }
}
