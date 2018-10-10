using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.ViewModels.UserDataViewModels
{
    interface IUserDataViewModel
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
