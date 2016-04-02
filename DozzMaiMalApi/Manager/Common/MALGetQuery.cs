using DozzMaiMalApi.Entity.Essentials;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi.Manager.Common
{
    public class MALGetQuery : MALQuery
    {
        private string userName;
        private int dataOffset;
        private MALListStatus queryStatus;


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //
        //                                                                      METHODS                                                                         //
        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public MALGetQuery(MalClient malClient, Entity.Essentials.MALType type, int offset = 0, MALListStatus status = MALListStatus.All)
            : base(malClient, type)
        {
            userName = malClient.User.UserName;
            dataOffset = offset;
            queryStatus = status;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public MALGetQuery(MalClient malClient, Entity.Essentials.MALType type, string uName, int offset = 0, MALListStatus status = MALListStatus.All)
            : base(malClient, type)
        {
            userName = uName;
            dataOffset = offset;
            queryStatus = status;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        // This method is not complete, complete the code that converts the JSON list to a usable list!!!
        public async override Task<string> Query()
        {
            // Generate query string
            QueryString = Uri.EscapeUriString($"http://myanimelist.net/{QueryType.ToString().ToLower()}list/{userName}/load.json?offset={dataOffset}&status={Convert.ToInt32(queryStatus)}");
            
            // Get response string asyncronously
            string respString = await base.Query();
            
            // Return anime list json
            return GetListData(respString);
        }
        

        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        private string GetListData(string dataItems)
        {
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(dataItems));

            // Create a json text reader and read the hson data as an array
            var jsonTextReader = new JsonTextReader(new StreamReader(memStream));
            var jArray = JArray.Load(jsonTextReader);

            var jObject = jArray;

            string animeList = jObject.ToString();

            return animeList;
        }
    }
}
