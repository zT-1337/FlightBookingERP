using System;

namespace FlighBooking_ThomasZerr.ViewModels.UserDataViewModels
{
    public interface IUserDataViewModel
    {
        string Username { get; set; }
        string Password { get; set; }
        Exception CaughtException { get; }
        bool IsLoginValid();
    }
}
