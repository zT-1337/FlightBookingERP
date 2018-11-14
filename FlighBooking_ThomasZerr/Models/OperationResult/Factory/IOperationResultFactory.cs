using System;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    interface IOperationResultFactory
    {
        IOperationResult CreateSuccess();
        IOperationResult CreateException(Exception exception);
    }
}
