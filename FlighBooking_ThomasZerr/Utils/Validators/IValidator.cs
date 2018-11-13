namespace FlighBooking_ThomasZerr.Utils.Validators
{
    public interface IValidator
    {
        object ExtraParam { get; set; }

        void IsValid(object value);
    }
}
