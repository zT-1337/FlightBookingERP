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
        public IOperationResult CreateSuccess()
        {
            return new OperationResultImpl("Operation erfolgreich ausgeführt" + " " + DateTime.Now.ToString("G"), ReturnCode.Success);
        }

        public IOperationResult CreateException(Exception exception)
        {
            string message = CreateMessageForException(exception);
            message = message + " " + DateTime.Now.ToString("G");

            return new OperationResultImpl(message, ReturnCode.Exception);
        }

        private string CreateMessageForException(Exception exception)
        {
            switch (exception.Message)
            {
                case "Eintrag für die Buchung bereits gesperrt (Tabelle SBOOK)":
                    return "Operation nicht durchführbar. Eintrag der Flugbuchung gesperrt.";
                case "Eintrag für den Flug bereits gesperrt (Tabelle SFLIGHT)":
                    return "Operation nicht durchführbar. Eintrag des Fluges gesperrt";
                case "Die HTTP-Anforderung ist beim Clientauthentifizierungsschema \"Basic\" nicht autorisiert. Vom Server wurde der Authentifizierungsheader \"Basic realm=\"SAP NetWeaver Application Server [I48/902]\"\" empfangen.":
                    return "Benutzername oder Passwort sind ungültig";
                default:
                    return exception.Message;
            }
        }
    }
}
