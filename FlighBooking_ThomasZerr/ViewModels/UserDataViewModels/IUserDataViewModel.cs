using FlighBooking_ThomasZerr.Models.OperationResults;

namespace FlighBooking_ThomasZerr.ViewModels.UserDataViewModels
{
    public interface IUserDataViewModel
    {
        string Username { get; set; }
        string Password { get; set; }
        IOperationResult OperationResult { get; }
        bool IsLoginValid();
    }
}
