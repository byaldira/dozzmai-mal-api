using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DozzMaiMalApi.Entity.Essentials;
using DozzMaiMalApi.Entity.DTO;
using System.Xml;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json.Linq;

/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File Created and Add method is ready for testing <-> 17.02.2016 : 17.43 +02.00 <-> Lolerji
    -> Bugfix in AddAnime method! Method now fully      <-> 17.02.2016 : 17.52 +02.00 <-> Lolerji
       fully functional... API Document is wrong!
       use Http GET not Http POST!!!!!!!!!!!!!!!!
    -> Update Anime method added and Unnecessary byte[] <-> 24.02.2016 : 20.45 +02.00 <-> Lolerji
       has been removed...
    -> Add, Update, Delete Anime methods have been      <-> 22.03.2016 : 17.11 +02.00 <-> Lolerji
       updated, they now use the MALQuery classes for 
       managing the queries

*/

namespace DozzMaiMalApi.Manager
{
    public class AnimeListManager : IManager
    {
        private MalClient malClient;

        public AnimeListManager(MalClient client)
        {
            malClient = client;
        }
        

        // -----------------------------------------------------------------------------------------------------------------------------------------------------//
        //                                                                      METHODS                                                                         //
        // -----------------------------------------------------------------------------------------------------------------------------------------------------//


        public async Task<object> GetAnimeList(int page = 0, MALListStatus status = MALListStatus.All)
        {
            if (malClient.User.IsAuthenticated)
            {
                // Create query
                var getQuery = new Common.MALGetQuery(malClient, MALType.Anime, page * 300, status);
                
                var animeListJson = await getQuery.Query();     // Get anime list as a json string
                var jArray = JArray.Parse(animeListJson);       // Parse the json string into a JSON Array

                // Populate anime list
                var animeList = new List<JSONAnime>();
                jArray.ToList().ForEach(anime => animeList.Add(anime.ToObject<JSONAnime>()));

                // Return anime list
                return animeList;
            }
            
            return null;
        }


        public async Task<string> Add(IMalListEntity iMalEntity)
        {
            // If the user is authenticated
            if (malClient.User.IsAuthenticated)
            {
                // Create query
                var addQuery = new Common.MALAddQuery(malClient, MALType.Anime)
                { IMalEntity = iMalEntity };                    // Assign mal entity

                // Return response
                return await addQuery.Query();
            }


            return "Failed!";
        }


        public async Task<string> Update(IMalListEntity iMalEntity)
        {
            if (malClient.User.IsAuthenticated)
            {
                // Create query
                var updateQuery = new Common.MALUpdateQuery(malClient, MALType.Anime)
                { IMalEntity = iMalEntity };        // Assign mal entity

                // Return response string
                return await updateQuery.Query();
            }

            // Else return error response
            return "Failed!";
        }


        public async Task<string> Delete(IMalListEntity iMalEntity)
        {
            if (malClient.User.IsAuthenticated)
            {
                // Create query
                var deleteQuery = new Common.MALDeleteQuery(malClient, MALType.Anime)
                { IMalEntity = iMalEntity };        // Assign mal entity

                // Return response string
                return await deleteQuery.Query() as string;
            }

            // Else return error response
            return "Failed!";
        }
    }
}
