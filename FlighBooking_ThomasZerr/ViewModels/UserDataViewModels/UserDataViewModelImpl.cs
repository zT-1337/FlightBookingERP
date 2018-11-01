using System;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.UserDataViewModels
{
    class UserDataViewModelImpl : NotifyPropertyChanged, IUserDataViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private Exception caughtException_;

        public Exception CaughtException
        {
            get => caughtException_;
            private set
            {
                caughtException_ = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoginValid()
        {
            if (Username.Length < 1)
            {
                CaughtException = new Exception("Benutzername darf nicht leer sein");
                return false;
            }

            if (Password.Length < 1)
            {
                CaughtException = new Exception("Passwort darf nicht leer sein");
                return false;
            }

            CaughtException = null;
            return true;
        }
    }
}
