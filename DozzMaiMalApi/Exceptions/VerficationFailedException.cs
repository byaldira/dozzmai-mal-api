using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi
{
    public class VerficationFailedException : Exception
    {
        private string message;

        public VerficationFailedException(string msg)
        {
            message = msg;
        }

        public override string Message
        {
            get
            {
                return message;
            }
        }
    }
}
