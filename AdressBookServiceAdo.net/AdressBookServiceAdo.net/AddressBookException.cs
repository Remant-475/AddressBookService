using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBookServiceAdo.net
{

        public class AddressException : Exception
        {

            ExceptionType exceptionType;
            public enum ExceptionType
            {
                Connection_Failed, Contact_Not_Add, ContactDetails_Not_Edited
        }
            public AddressException(ExceptionType exceptionType, string message) : base(message)
            {
                this.exceptionType = exceptionType;
            }
        }
}
