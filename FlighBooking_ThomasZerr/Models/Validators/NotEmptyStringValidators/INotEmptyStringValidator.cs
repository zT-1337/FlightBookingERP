namespace FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidators
{
    interface INotEmptyStringValidator : IValidator
    {
        string PropertyName { get; set; }
    }
}
