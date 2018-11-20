using FlighBooking_ThomasZerr.Models.OperationResults.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResults
{
    public interface IOperationResult
    {
        string Message { get;}
        ReturnCode ReturnCode { get;}
    }
}
