using FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators;
using FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators;
using FlighBooking_ThomasZerr.Models.Validators.FlightClassValidators;
using FlighBooking_ThomasZerr.Models.Validators.MaxResultsValidators;
using FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidators;
using FlighBooking_ThomasZerr.Models.Validators.TravelAgencyIdValidators;

namespace FlighBooking_ThomasZerr.Models.Validators.Factorys
{
    interface IValidatorFactory
    {
        IAirlineIdValidator CreateAirlineIdValidator();
        ICustomerIdValidator CreateCustomerIdValidator();
        IDateRangeValidator CreateDateRangeValidator();
        IFlightClassValidator CreateFlightClassValidator();
        IMaxResultsValidator CreateMaxResultsValidator();
        INotEmptyStringValidator CreateNotEmptyStringValidator();
        ITravelAgencyIdValidator CreateTravelAgencyIdValidator();
    }
}
