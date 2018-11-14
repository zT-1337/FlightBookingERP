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
using FlighBooking_ThomasZerr.Models.OperationResult.Factory;
using FlighBooking_ThomasZerr.Models.Proxys.FlightBookingProxys;
using FlighBooking_ThomasZerr.Models.Validators;
using FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators;
using FlighBooking_ThomasZerr.Models.Validators.Factorys;
using FlighBooking_ThomasZerr.Models.Validators.MaxResultsValidators;
using FlighBooking_ThomasZerr.Models.Validators.TravelAgencyIdValidators;
using FlighBooking_ThomasZerr.ViewModels.FlightBookingEditViewModels;

namespace FlighBooking_ThomasZerr.Views.FlightBookingEditWindows.Factorys
{
    class FlightBookingEditWindowFactorySAP : IFlightBookingEditWindowFactory
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private IValidatorFactory validatorFactory_;

        public FlightBookingEditWindow Create()
        {
            validatorFactory_ = new ValidatorFactorySAP();

            var editViewModel = CreateViewModel();
            return new FlightBookingEditWindow(editViewModel);
        }

        private IFlightBookingEditViewModel CreateViewModel()
        {
            var flightBookingFactory = CreateFlightBookingFactory();
            var defaultFlightBookingData = CreateDefaultFlightBookingArgs();
            var operationResultFactory = CreateOperationResultFactory();

            var airlineIdValidator = validatorFactory_.CreateAirlineIdValidator();
            var travelAgencyIdValidator = validatorFactory_.CreateTravelAgencyIdValidator();
            var customerIdValidator = validatorFactory_.CreateCustomerIdValidator();
            var dateRangeValidator = validatorFactory_.CreateDateRangeValidator();
            var maxResultsValidator = validatorFactory_.CreateMaxResultsValidator();

            return new FlightBookingEditViewModelImpl(flightBookingFactory, 
                defaultFlightBookingData, 
                new ObservableCollection<IFlightBooking>(),
                operationResultFactory,
                airlineIdValidator, travelAgencyIdValidator, customerIdValidator,
                dateRangeValidator, maxResultsValidator);
        }

        private IFlightBookingFactory CreateFlightBookingFactory()
        {
            var proxyFlightBooking = new ProxyFlightBookingSAP
            {
                Username = Username,
                Password = Password
                
            };

            return new FlightBookingFactoryImpl(proxyFlightBooking);
        }

        private IFlightBookingData CreateDefaultFlightBookingArgs()
        {
            var flightBookingData = new FlightBookingDataSAP
            {
                BookingId = "",
                CustomerId = "",
                Class = "",
                Counter = "",
                AgencyId = "",
                PassagierName = "",
                Reserved = false,
                Cancelled = false,
            };

            flightBookingData.FlightDateRange.Option = DateRangeOption.Between;
            flightBookingData.FlightDateRange.EarlierDateTime = DateTime.Now;
            flightBookingData.FlightDateRange.LaterDateTime = DateTime.Now;

            flightBookingData.BookingDateRange.Option = DateRangeOption.Between;
            flightBookingData.BookingDateRange.EarlierDateTime = DateTime.Now;
            flightBookingData.BookingDateRange.LaterDateTime = DateTime.Now;

            return flightBookingData;
        }

        private IOperationResultFactory CreateOperationResultFactory()
        {
            return new OperationResultFactoryImpl();
        }
    }
}
