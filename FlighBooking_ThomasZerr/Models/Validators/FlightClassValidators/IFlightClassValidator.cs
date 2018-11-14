namespace FlighBooking_ThomasZerr.Models.Validators.FlightClassValidators
{
    interface IFlightClassValidator : IValidator
    {
        string[] FlightClasses { get; set; }
    }
}
