using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    class OperationResultFactoryLogin : IOperationResultFactory
    {
        private IOperationResult successOperationResult_;

        public OperationResultFactoryLogin()
        {
            successOperationResult_ = new OperationResultImpl("Ok", ReturnCode.Success);
        }

        public IOperationResult CreateSuccess()
        {
            return successOperationResult_;
        }

        public IOperationResult CreateException(Exception exception)
        {
            return new OperationResultImpl(exception.Message, ReturnCode.Exception);
        }
    }
}
