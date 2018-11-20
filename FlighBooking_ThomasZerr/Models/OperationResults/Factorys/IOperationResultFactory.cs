using System;

namespace FlighBooking_ThomasZerr.Models.OperationResults.Factorys
{
    interface IOperationResultFactory
    {
        IOperationResult CreateSuccess();
        IOperationResult CreateException(Exception exception);
    }
}
