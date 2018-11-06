using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult
{
    class OperationResultImpl : IOperationResult
    {
        public string Message { get; set; }
        public ReturnCode ReturnCode { get; set; }
    }
}
