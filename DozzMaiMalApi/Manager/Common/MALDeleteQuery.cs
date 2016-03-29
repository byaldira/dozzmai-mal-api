using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi.Manager.Common
{
    public class MALDeleteQuery : MALQuery
    {
        public MALDeleteQuery(MalClient malClient, Entity.Essentials.MALType type)
            : base(malClient, type)
        { }


        public override async Task<string> Query()
        {
            // iMalEntity must be initialized!
            if (IMalEntity == null)
            {
                throw new Exception("A MyAnimList entity object is required for this query!!");
            }

            // Generate query string
            QueryString = Uri.EscapeUriString($"http://myanimelist.net/api/{QueryType.ToString().ToLower()}list/delete/{IMalEntity.ID}.xml");

            // Return the result of the query
            return await base.Query();
        }
    }
}
