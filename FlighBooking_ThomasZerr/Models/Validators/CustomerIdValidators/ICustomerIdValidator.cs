namespace FlighBooking_ThomasZerr.Models.Validators.CustomerIdValidators
{
    interface ICustomerIdValidator : IValidator
    {
        int MaxLength { get; set; }
    }
}
