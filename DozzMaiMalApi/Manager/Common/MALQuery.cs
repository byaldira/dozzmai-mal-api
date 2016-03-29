using DozzMaiMalApi.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DozzMaiMalApi.Manager.Common
{
    public class MALQuery
    {
        private Entity.Essentials.IMalListEntity iMalEntity;
        private Entity.Essentials.MALType queryType;
        private MalClient client;
        private string queryString;


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //
        //                                                                      METHODS                                                                         //
        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public MALQuery(MalClient malClient, Entity.Essentials.MALType type)
        {
            queryString = "http://myanimelist.net/";
            client = malClient;
            queryType = type;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public virtual async Task<string> Query()
        {
            var stream = await client.HttpClient.GetStreamAsync(QueryString);

            // Get response string
            var reader = new StreamReader(stream);
            var respString = reader.ReadToEnd();

            return respString;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------- //


        public StringBuilder GenerateXMLData()
        {
            // Convert the interface object to a dto anime object
            var anime = IMalEntity as DTOListAnime;

            // Here we should convert the anime data to xml fromat to
            // dispatch to myanimelist, MAL only accepts xml format data <.<
            var settings = new XmlWriterSettings();
            settings.Indent = true;             // We want indentation in our xml!!!
            settings.CheckCharacters = true;    // We want to check if the characters in our xml is valid!

            try
            {
                var xml = new StringBuilder();
                xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                xml.AppendLine("<entry>");
                xml.AppendLine($"<episode>{anime.Episode}</episode>");
                xml.AppendLine($"<status>{anime.Status}</status>");
                xml.AppendLine($"<score>{anime.Score}</score>");
                xml.AppendLine($"<download_episodes>{anime.Downloaded}</download_episodes>");
                xml.AppendLine($"<storage_type>{anime.StorageType}</storage_type>");
                xml.AppendLine($"<storage_value>{anime.StorageValue}</storage_value>");
                xml.AppendLine($"<times_rewatched>{anime.TimesRewRer}</times_rewatched>");
                xml.AppendLine($"<rewatch_value>{anime.RewRerValue}</rewatch_value>");
                xml.AppendLine($"<date_start>{anime.DateStarted}</date_start>");
                xml.AppendLine($"<date_finish>{anime.DateFinished}</date_finish>");
                xml.AppendLine($"<priority>{anime.Priority}</priority>");
                xml.AppendLine($"<enable_discussion>{anime.EnableDisscussion}</enable_discussion>");
                xml.AppendLine($"<enable_rewatching>{anime.EnableRewRer}</enable_rewatching>");
                xml.AppendLine($"<comments>{anime.Comments}</comments>");
                xml.AppendLine($"<fansub_group>{anime.Group}</fansub_group>");
                xml.AppendLine($"<tags>{anime.Tags}</tags>");
                xml.AppendLine("</entry>");

                // Return the memory stream that holds the anime data
                return xml;
            }
            catch (XmlException xmlEx)
            {
                Debug.WriteLine("XmlException: " + xmlEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }

            // Return null if exceptions occur...
            return null;
        }


        // -----------------------------------------------------------------------------------------------------------------------------------------------------//
        //                                                                      PROPERTIES                                                                      //
        // -----------------------------------------------------------------------------------------------------------------------------------------------------//


        public MalClient MalClient
        {
            get { return client; }
            protected set { client = value; }            
        }


        public string QueryString
        {
            get { return queryString; }
            protected set { queryString = value; }
        }


        public Entity.Essentials.MALType QueryType
        {
            get { return queryType; }
            protected set { queryType = value; }
        }
        

        public Entity.Essentials.IMalListEntity IMalEntity
        {
            get { return iMalEntity; }
            set { iMalEntity = value; }
        }
    }
}
