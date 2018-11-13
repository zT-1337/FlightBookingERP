using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    class OperationResultFactoryImpl : IOperationResultFactory
    {

        public IOperationResult CreateSuccess()
        {
            return new OperationResultImpl($"Ok (Zeit: {DateTime.Now:g})", ReturnCode.Success);
        }

        public IOperationResult CreateException(Exception exception)
        {
            return new OperationResultImpl($"{exception.Message} (Zeit: {DateTime.Now:g}", ReturnCode.Exception);
        }
    }
}
