using FlighBooking_ThomasZerr.Models.OperationResults.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResults
{
    class OperationResultImpl : IOperationResult
    {
        public string Message { get;}
        public ReturnCode ReturnCode { get;}

        public OperationResultImpl(string message, ReturnCode returnCode)
        {
            Message = message;
            ReturnCode = returnCode;
        }
    }
}
