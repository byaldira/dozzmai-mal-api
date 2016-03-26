using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi.Manager.Common
{
    public class MALGetQuery : MALQuery
    {
        private string userName;

        public MALGetQuery(MalClient malClient)
            : base(malClient)
        { userName = malClient.User.UserName; }

        public MALGetQuery(MalClient malClient, string uName)
            : base(malClient)
        { userName = uName; }

        // This method is not complete, complete the code that converts the JSON list to a usable list!!!
        public async override Task<string> Query()
        {
            // Generate query string
            QueryString = Uri.EscapeUriString($"http://myanimelist.net/animelist/{userName}");
            
            // Get response string asyncronously
            string respString = await base.Query();

            // Load html document returned as a http response
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(respString);

            // Get JSON formatted data
            var table = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='list-container']/div[3]/div//table/@data-items");
            string dataItems = table.Attributes.AttributesWithName("data-items").First().Value;

            dynamic animeList = GetListData(dataItems);

            string data = string.Empty;
            foreach (var anime in animeList)
            {
                data += anime.anime_title + ", "
                        + anime.anime_url + ", "
                        + anime.anime_image_path + ", "
                        + anime.is_added_to_list + ", "
                        + anime.anime_airing_status + ", "
                        + anime.num_watched_episodes + ", "
                        + anime.anime_num_episodes + ", "
                        + ";";
            }

            return data;
        }

        private dynamic GetListData(string dataItems)
        {
            return string.Empty;
        }
    }
}
