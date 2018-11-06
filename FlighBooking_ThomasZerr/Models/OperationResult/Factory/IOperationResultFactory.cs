using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    interface IOperationResultFactory
    {
        IOperationResult CreateSuccess();
        IOperationResult CreateException(Exception exception);
    }
}
