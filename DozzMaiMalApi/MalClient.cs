using DozzMaiMalApi.Entity;
using DozzMaiMalApi.Manager;
using DozzMaiMalApi.Manager.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File and class created code added                <-> 17.02.2016 : 00.12 +02.00   <-> Lolerji
    -> AnimeQuery method added                          <-> 17.02.2016 : 00.26 +02.00   <-> Lolerji
    -> GetAnimeEntry method added                       <-> 17.02.2016 : 00.26 +02.00   <-> Lolerji
    -> StringToQueryParameter method added              <-> 17.02.2016 : 00.26 +02.00   <-> Lolerji
    -> AnimeListManager is added to client              <-> 17.02.2016 : 17.31 +02.00   <-> Lolerji
    -> Migrating the from web client to HttpClient      <-> 18.02.2016 : 08.30 +02.00   <-> Lolerji
    -> AnimeQuery has been deleted and AnimeSearch      <-> 29.03.2016 : 22.34 +02.00   <-> Lolerji 
       is added instead, it uses the new MALQuery
       objects to search animes instead of deprecated
       Manager Utility

*/


namespace DozzMaiMalApi
{
    public class MalClient
    {
        private readonly HttpClient httpClient;
        private MALUser user;
        private AnimeListManager animeListManager;

        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //
        //                                                                      METHODS                                                                         //
        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public MalClient()
        {
            // Initialize web client
            httpClient = new HttpClient();

            // Initialize user
            user = new MALUser(this);

            // Initialize managers
            animeListManager = new AnimeListManager(this);
            // MANGA LIST MANAGER WILL BE INITIALIZED HERE
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public async Task<IEnumerable<MALAnime>> AnimeSearch(string name)
        {
            // If the user is authenticated
            if (User.IsAuthenticated)
            {
                try
                {
                    // Create search query
                    var searchQuery = new MALSearchQuery(this, Entity.Essentials.MALType.Anime)
                    { IMalEntity = new Entity.DTO.DTOListAnime() { Name = name } };

                    // Get query response
                    var resp = await searchQuery.Query();

                    // Get xml document from the response
                    var document = new XmlDocument();
                    document.LoadXml(resp);

                    // Get root of the xml document
                    var root = document.DocumentElement;
                    var animeList = new List<MALAnime>();

                    // Populate anime list
                    foreach (var child in root)
                    {
                        var c = child as XmlNode;

                        // If the node is an entry node
                        if (c.Name == "entry")
                            animeList.Add(GetAnimeFromEntry(c));    // Add the anime underlying anime data to the list
                    }

                    // Return anime list
                    return (IEnumerable<MALAnime>)animeList;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }
            }

            // Return null if user is not authenticated
            return null;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        private MALAnime GetAnimeFromEntry(object element)
        {
            // Convert element to xml element
            var xmlElement = element as XmlElement;

            // Create a new empty anime object
            var anime = new MALAnime();

            foreach (var item in xmlElement)
            {
                var c = item as XmlNode;

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


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //
        //                                                                      PROPERTIES                                                                      //
        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        private string StringToQueryParameter(string param)
        {
            return param.ToLower().Replace(' ', '+');
        }

        
        public MALUser User
        {
            get { return user; }
        }


        public AnimeListManager AnimeListManager
        {
            get { return animeListManager; }
        }


        internal HttpClient HttpClient
        {
            get { return httpClient; }
        }
    }
}
