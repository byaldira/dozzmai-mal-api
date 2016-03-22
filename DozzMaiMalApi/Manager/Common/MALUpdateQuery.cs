using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi.Manager.Common
{
    public class MALUpdateQuery : MALQuery
    {
        public MALUpdateQuery(MalClient malClient)
            : base(malClient)
        { }

        public override async Task<string> Query()
        {
            // iMalEntity must be initialized!
            if (IMalEntity == null)
            {
                throw new Exception("A MyAnimList entity object is required for this query!!");

            }

            // Generate xml data and query string
            var xmlData = GenerateXMLData();
            QueryString = Uri.EscapeUriString($"http://myanimelist.net/api/animelist/update/{IMalEntity.ID}.xml?data={xmlData}");

            // Return the result of the query
            return await base.Query();
        }
    }
}
