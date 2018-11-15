using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult
{
    public interface IOperationResult
    {
        string Message { get;}
        ReturnCode ReturnCode { get;}
    }
}
