using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators;
using FlighBooking_ThomasZerr.Models.Validators.FlightClassValidators;
using FlighBooking_ThomasZerr.Models.Validators.MaxResultsValidators;
using FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidators;
using FlighBooking_ThomasZerr.Models.Validators.TravelAgencyIdValidators;

namespace FlighBooking_ThomasZerr.Models.Validators.Factorys
{
    class ValidatorFactorySAP : IValidatorFactory
    {
        private IAirlineIdValidator airlineIdValidator_;
        private ICustomerIdValidator customerIdValidator_;
        private IDateRangeValidator dateRangeValidator_;
        private IFlightClassValidator flightClassValidator_;
        private IMaxResultsValidator maxResultsValidator_;
        private INotEmptyStringValidator notEmptyStringValidator_;
        private ITravelAgencyIdValidator travelAgencyIdValidator_;

        public ValidatorFactorySAP()
        {
            airlineIdValidator_ = new AirlineIdValidator {MaxLength = 3};
            customerIdValidator_ = new CustomerIdValidator {MaxLength = 8};
            dateRangeValidator_ = new DateRangeValidator();
            flightClassValidator_ = new FlightClassValidator{FlightClasses = new []{"C", "F", "Y"}};
            maxResultsValidator_ = new MaxResultsValidator();
            notEmptyStringValidator_ = new NotEmptyStringValidatorImpl();
            travelAgencyIdValidator_ = new TravelAgencyIdValidator {MaxLength = 8};
        }

        public IAirlineIdValidator CreateAirlineIdValidator()
        {
            return airlineIdValidator_;
        }

        public ICustomerIdValidator CreateCustomerIdValidator()
        {
            return customerIdValidator_;
        }

        public IDateRangeValidator CreateDateRangeValidator()
        {
            return dateRangeValidator_;
        }

        public IFlightClassValidator CreateFlightClassValidator()
        {
            return flightClassValidator_;
        }

        public IMaxResultsValidator CreateMaxResultsValidator()
        {
            return maxResultsValidator_;
        }

        public INotEmptyStringValidator CreateNotEmptyStringValidator()
        {
            return notEmptyStringValidator_;
        }

        public ITravelAgencyIdValidator CreateTravelAgencyIdValidator()
        {
            return travelAgencyIdValidator_;
        }
    }
}
