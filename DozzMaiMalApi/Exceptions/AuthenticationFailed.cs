using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi
{
    public class AuthenticationFailed : Exception
    {
        private string message;

        public AuthenticationFailed(string msg)
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
