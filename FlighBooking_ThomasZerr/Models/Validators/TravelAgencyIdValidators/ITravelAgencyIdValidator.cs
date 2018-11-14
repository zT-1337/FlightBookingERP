
namespace FlighBooking_ThomasZerr.Models.Validators.TravelAgencyIdValidators
{
    interface ITravelAgencyIdValidator : IValidator
    {
        int MaxLength { get; set; }
    }
}
