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
        private IOperationResult successResult_;

        public OperationResultFactorySAP()
        {
            successResult_ = new OperationResultImpl("Operation erfolgreich ausgeführt", ReturnCode.Success);
        }

        public IOperationResult CreateSuccess()
        {
            return successResult_;
        }

        public IOperationResult CreateException(Exception exception)
        {
            string message = CreateMessageForException(exception);

            return new OperationResultImpl(message, ReturnCode.Exception);
        }

        private string CreateMessageForException(Exception exception)
        {
            switch (exception.Message)
            {
                    default:
                        return exception.Message;
            }
        }
    }
}
