using System;
using FlighBooking_ThomasZerr.Models.OperationResults;
using FlighBooking_ThomasZerr.Models.OperationResults.Factory;
using FlighBooking_ThomasZerr.Utils;

namespace FlighBooking_ThomasZerr.ViewModels.UserDataViewModels
{
    class UserDataViewModelImpl : NotifyPropertyChanged, IUserDataViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private readonly IOperationResultFactory operationResultFactory_;
        private IOperationResult operationResult_;
        public IOperationResult OperationResult
        {
            get => operationResult_;
            private set
            {
                operationResult_ = value;
                RaisePropertyChanged();
            }
        }

        public UserDataViewModelImpl()
        {
            operationResultFactory_ = new OperationResultFactoryImpl();
        }

        public bool IsLoginValid()
        {
            if (Username.Length < 1)
            {
                OperationResult = operationResultFactory_.CreateException(new Exception("Der Benutzername darf nicht leer sein"));
                return false;
            }

            if (Password.Length < 1)
            {
                OperationResult = operationResultFactory_.CreateException(new Exception("Passwort darf nicht leer sein"));
                return false;
            }

            OperationResult = operationResultFactory_.CreateSuccess();
            return true;
        }
    }
}
