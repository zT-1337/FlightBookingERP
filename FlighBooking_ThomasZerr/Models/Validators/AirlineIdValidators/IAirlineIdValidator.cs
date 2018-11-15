namespace FlighBooking_ThomasZerr.Models.Validators.AirlineIdValidators
{
    interface IAirlineIdValidator : IValidator
    {
        int MaxLength { get; set; }
    }
}
