﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlighBooking_ThomasZerr.Models.OperationResult.ReturnCodes;

namespace FlighBooking_ThomasZerr.Models.OperationResult.Factory
{
    class OperationResultFactoryCreateSAP : IOperationResultFactory
    {
        private IOperationResult successResult_;

        public OperationResultFactoryCreateSAP()
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
                case "Der Objektverweis wurde nicht auf eine Objektinstanz festgelegt.":
                    return "Wählen sie zunächst einen Flug aus";
                case "Eintrag für den Flug bereits gesperrt (Tabelle SFLIGHT)":
                    return "Operation wird bereits ausgeführt";
                default:
                    return exception.Message;
            }
        }
    }
}