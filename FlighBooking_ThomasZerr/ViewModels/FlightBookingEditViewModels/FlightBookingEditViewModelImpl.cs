using System;
using System.Collections.ObjectModel;
using FlighBooking_ThomasZerr.Models.FlightBookings;
using FlighBooking_ThomasZerr.Models.FlightBookings.Factorys;
using FlighBooking_ThomasZerr.Models.FlightBookings.FlightBookingDatas;
using FlighBooking_ThomasZerr.Models.OperationResult;
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels
{
    class FlightBookingEditViewModelImpl : NotifyPropertyChanged, IFlightBookingEditViewModel
    {
        private IFlightBookingFactory flightBookingFactory_;

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
            IOperationResultFactory operationResultFactory)
        {
            flightBookingFactory_ = flightBookingFactory;
            Args = defaultArgs;
            RetrievedFlightBookings = retrievedFlightBookings;
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
