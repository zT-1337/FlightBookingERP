using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    class OperationResultFactorySAP : IOperationResultFactory
    {
        public IOperationResult CreateSuccess()
        {
            return new OperationResultImpl
            {
                Message = "Operation erfolgreich ausgeführt",
                ReturnCode = ReturnCode.Success
            };
        }

        public IOperationResult CreateException(Exception exception)
        {
            string message = createMessageForException(exception);

            return new OperationResultImpl
            {
                Message = message,
                ReturnCode = ReturnCode.Exception
            };
        }

        private string createMessageForException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
