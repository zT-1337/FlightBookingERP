using System;
using FlighBooking_ThomasZerr.Models.OperationResults.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResults.Factory
{
    class OperationResultFactoryImpl : IOperationResultFactory
    {

        public IOperationResult CreateSuccess()
        {
            return new OperationResultImpl($"Ok (Zeit: {DateTime.Now:T})", ReturnCode.Success);
        }

        public IOperationResult CreateException(Exception exception)
        {
            return new OperationResultImpl($"{exception.Message} (Zeit: {DateTime.Now:T})", ReturnCode.Exception);
        }
    }
}
