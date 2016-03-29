using DozzMaiMalApi.Entity;
using DozzMaiMalApi.Manager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DozzMaiMalApi.Manager
{
    public class MALSearchQuery : MALQuery
    {
        public MALSearchQuery(MalClient malClient, Entity.Essentials.MALType type)
            : base(malClient, type)
        { }
        

        public async override Task<string> Query()
        {
            QueryString = Uri.EscapeUriString($"http://myanimelist.net/api/{QueryType.ToString().ToLower()}/search.xml?q={StringToQueryParameter(IMalEntity.Name)}");

            return await base.Query();
        }

        
        private string StringToQueryParameter(string param)
        {
            return param.ToLower().Replace(' ', '+');
        }
    }
}
