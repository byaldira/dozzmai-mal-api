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


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //
        //                                                                      METHODS                                                                         //
        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public MALGetQuery(MalClient malClient, Entity.Essentials.MALType type)
            : base(malClient, type)
        { userName = malClient.User.UserName; }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public MALGetQuery(MalClient malClient, Entity.Essentials.MALType type, string uName)
            : base(malClient, type)
        { userName = uName; }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        // This method is not complete, complete the code that converts the JSON list to a usable list!!!
        public async override Task<string> Query()
        {
            // Generate query string
            QueryString = Uri.EscapeUriString($"http://myanimelist.net/{QueryType.ToString().ToLower()}list/{userName}");
            
            // Get response string asyncronously
            string respString = await base.Query();

            // Load html document returned as a http response
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(respString);

            // Get JSON formatted data
            var table = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='list-container']/div[3]/div//table/@data-items");
            string dataItems = table.Attributes.AttributesWithName("data-items").First().Value.Replace("&quot;", "'");
            
            // Return anime list json
            return GetListData(dataItems);
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
