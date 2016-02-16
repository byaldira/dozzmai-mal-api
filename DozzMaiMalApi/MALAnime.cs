using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DozzMaiMalApi
{
    public class MALAnime
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string English { get; set; }
        public string Synonyms { get; set; }
        public int Episodes { get; set; }
        public double Score { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Synopsis { get; set; }
        public string ImageUrl { get; set; }
    }
}
