using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DozzMaiMalApi
{
    public class MalClient
    {
        private readonly WebClient webClient;
        private MALUser user;

        public MalClient()
        {
            // Initialize web client
            webClient = new WebClient();

            // Set dummy user credentials
            user = new MALUser("cemkck", "62qypvrj6fja", webClient);
        }
    }
}
