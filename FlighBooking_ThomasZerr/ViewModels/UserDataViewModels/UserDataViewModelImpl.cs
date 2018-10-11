using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.ViewModels.UserDataViewModels
{
    class UserDataViewModelImpl : IUserDataViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
