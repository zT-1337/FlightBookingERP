using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.Validators.DateRangeValidators
{
    interface IDateRangeValidator : IValidator
    {
        DateTime LaterDateTime { get; set; }
    }
}
