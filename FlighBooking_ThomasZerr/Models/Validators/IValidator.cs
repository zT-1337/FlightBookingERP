namespace FlighBooking_ThomasZerr.Models.Validators
{
    public interface IValidator
    {
        void IsValidElseThrowException(object value);
    }
}
