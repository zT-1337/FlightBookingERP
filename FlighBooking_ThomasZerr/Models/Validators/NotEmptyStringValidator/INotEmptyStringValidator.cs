namespace FlighBooking_ThomasZerr.Models.Validators.NotEmptyStringValidator
{
    interface INotEmptyStringValidator : IValidator
    {
        string PropertyName { get; set; }
    }
}
