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

            // Initialize user
            user = new MALUser(webClient);
        }



        #region Methods

        #region -> Public Usage Methods

        public IEnumerable<MALAnime> AnimeQuery(string str)
        {
            try
            {
                // Generate anime query string
                string param = StringToQueryParameter(str);
                string queryString = "http://myanimelist.net/api/anime/search.xml?q=" + param;

                string xml = webClient.DownloadString(queryString);

                // Create xml document
                var document = new XmlDocument();
                document.LoadXml(xml);      // Read the xml data from the string

                // DEBUG!!!
                // Get the root node in the xml
                var root = document.DocumentElement;

                // Create a queryable animes object
                var animeList = new List<MALAnime>();

                foreach (var child in root)
                {
                    var c = child as XmlNode;

                    // If the node is an entry node
                    if (c.Name == "entry")
                        animeList.Add(GetAnimeFromEntry(c));    // Add the anime underlying anime data to the list
                }

                // Return the queryable animes object
                return (IEnumerable<MALAnime>)animeList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }

            return null;
        }

        #endregion

        #region -> Essentials (Private)

        private MALAnime GetAnimeFromEntry(object element)
        {
            // Convert element to xml element
            var xmlElement = element as XmlElement;

            // Create a new empty anime object
            var anime = new MALAnime();

            foreach (var item in xmlElement)
            {
                var c = item as XmlNode;

                // DEBUG!!
                Debug.WriteLine(c.Name + " : " + c.InnerXml);

                // Fill anime data by node name
                switch (c.Name)
                {
                    case "id":
                        anime.ID = Convert.ToInt32(c.InnerXml);
                        break;

                    case "title":
                        anime.Title = c.InnerXml;
                        break;

                    case "english":
                        anime.English = c.InnerXml;
                        break;

                    case "sysnonyms":
                        anime.Synonyms = c.InnerXml;
                        break;

                    case "episodes":
                        anime.Episodes = Convert.ToInt32(c.InnerXml);
                        break;

                    case "score":
                        anime.Score = Convert.ToDouble(c.InnerXml);
                        break;

                    case "type":
                        anime.Type = c.InnerXml;
                        break;

                    case "status":
                        anime.Status = c.InnerXml;
                        break;

                    case "start_date":
                        anime.StartDate = c.InnerXml;
                        break;

                    case "end_date":
                        anime.EndDate = c.InnerXml;
                        break;

                    case "synopsis":
                        anime.Synopsis = c.InnerXml;
                        break;

                    case "image":
                        anime.ImageUrl = c.InnerXml;
                        break;
                }
            }

            return anime;
        }

        private string StringToQueryParameter(string param)
        {
            return param.Replace(' ', '+');
        }

        #endregion

        #endregion



        #region Properties

        public MALUser User
        {
            get { return user; }
        }

        #endregion
    }
}
