using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    class OperationResultFactoryEditSAP : IOperationResultFactory
    {
        private IOperationResult successResult_;

        public OperationResultFactoryEditSAP()
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
                case "Eintrag für den Flug bereits gesperrt (Tabelle SFLIGHT)":
                    return "Operation wird bereits ausgeführt";
                default:
                    return exception.Message;
            }
        }
    }
}
