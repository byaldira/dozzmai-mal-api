using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi.Entity.DTO
{
    public class JSONAnime
    {
        [JsonProperty("status")]
        public int status { get; set; }

        [JsonProperty("score")]
        public int score { get; set; }

        [JsonProperty("tags")]
        public string tags { get; set; }

        [JsonProperty("is_rewatching")]
        public int is_rewatching { get; set; }

        [JsonProperty("num_watched_episodes")]
        public int num_watched_episodes { get; set; }

        [JsonProperty("anime_title")]
        public string anime_title { get; set; }

        [JsonProperty("anime_num_episodes")]
        public int anime_num_episodes { get; set; }

        [JsonProperty("anime_airing_status")]
        public int anime_airing_status { get; set; }

        [JsonProperty("anime_id")]
        public int anime_id { get; set; }

        [JsonProperty("anime_studios")]
        public object anime_studios { get; set; }

        [JsonProperty("anime_licensors")]
        public object anime_licensors { get; set; }

        [JsonProperty("anime_season")]
        public object anime_season { get; set; }

        [JsonProperty("anime_url")]
        public string anime_url { get; set; }

        [JsonProperty("anime_image_path")]
        public string anime_image_path { get; set; }

        [JsonProperty("is_added_to_list")]
        public bool is_added_to_list { get; set; }

        [JsonProperty("anime_media_type_string")]
        public string anime_media_type_string { get; set; }

        [JsonProperty("anime_mpaa_rating_string")]
        public string anime_mpaa_rating_string { get; set; }

        [JsonProperty("start_date_string")]
        public object start_date_string { get; set; }

        [JsonProperty("finish_date_string")]
        public object finish_date_string { get; set; }

        [JsonProperty("anime_start_date_string")]
        public string anime_start_date_string { get; set; }

        [JsonProperty("anime_end_date_string")]
        public string anime_end_date_string { get; set; }

        [JsonProperty("days_string")]
        public object days_string { get; set; }

        [JsonProperty("storage_string")]
        public string storage_string { get; set; }

        [JsonProperty("priority_string")]
        public string priority_string { get; set; }
    }
}
