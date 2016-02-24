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

/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File Created and Add method is ready for testing <-> 17.02.2016 : 17.43 +02.00 <-> Lolerji
    -> Bugfix in AddAnime method! Method now fully      <-> 17.02.2016 : 17.52 +02.00 <-> Lolerji
       fully functional... API Document is wrong!
       use Http GET not Http POST!!!!!!!!!!!!!!!!
    -> Update Anime method added and Unnecessary byte[] <-> 24.02.2016 : 20.45 +02.00 <-> Lolerji
       has been removed...

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

        #region IManager Implementation

        public async Task<string> Add(IMalListEntity iMalEntity)
        {
            // If the user is authenticated
            if (malClient.User.IsAuthenticated)
            {
                // Get anime data as xml
                var xmlStrBuilder = ManagerUtility.GenerateXMLData(iMalEntity);

                var anime = iMalEntity as DTOListAnime;
                string queryString = ManagerUtility.GenerateQueryString(anime.ID, xmlStrBuilder, Common.ApiMethods.Add);

                // Upload data
                var respString = await ManagerUtility.Query(queryString, malClient);

                // Return response string
                return respString;
            }


            return "Failed!";
        }

        public async Task<string> Update(IMalListEntity iMalEntity)
        {
            if (malClient.User.IsAuthenticated)
            {
                // Get anime data as xml
                var xmlStrBuilder = ManagerUtility.GenerateXMLData(iMalEntity);

                var anime = iMalEntity as DTOListAnime;
                string queryString = ManagerUtility.GenerateQueryString(anime.ID, xmlStrBuilder, Common.ApiMethods.Update);

                // Upload data
                var respString = await ManagerUtility.Query(queryString, malClient);

                // Return response string
                return respString;
            }

            // Else return error response
            return "Failed!";
        }

        public async Task<string> Delete(IMalListEntity iMalEntity)
        {
            if (malClient.User.IsAuthenticated)
            {
                // Get anime data as xml
                var xmlStrBuilder = ManagerUtility.GenerateXMLData(iMalEntity);

                var anime = iMalEntity as DTOListAnime;
                string queryString = ManagerUtility.GenerateQueryString(anime.ID, xmlStrBuilder, Common.ApiMethods.Delete);

                // Upload data
                var respString = await ManagerUtility.Query(queryString, malClient);

                // Return response string
                return respString;
            }

            // Else return error response
            return "Failed!";
        }

        #endregion
    }
}
