using System;

namespace FlighBooking_ThomasZerr.Models.OperationResults.Factory
{
    interface IOperationResultFactory
    {
        IOperationResult CreateSuccess();
        IOperationResult CreateException(Exception exception);
    }
}
