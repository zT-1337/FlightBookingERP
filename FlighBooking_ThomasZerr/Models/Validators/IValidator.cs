namespace FlighBooking_ThomasZerr.Models.Validators
{
    public interface IValidator
    {
        object ExtraParam { get; set; }

        void IsValidElseThrowException(object value);
    }
}
