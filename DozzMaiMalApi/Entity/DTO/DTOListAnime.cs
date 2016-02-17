using DozzMaiMalApi.Entity.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File and class created code added    <-> 17.02.2016 : 14.53 +02.00 <-> Lolerji

*/


namespace DozzMaiMalApi.Entity.DTO
{
    public class DTOListAnime : IMalListEntity
    {
        public int ID { get; set; }

        public int Episode { get; set; }

        public int StorageType { get; set; }

        public float StorageValue { get; set; }

        public string Comments { get; set; }

        public DateTime DateFinished { get; set; }

        public DateTime DateStarted { get; set; }

        public int Downloaded { get; set; }

        public int EnableDisscussion { get; set; }

        public int EnableRewRer { get; set; }

        public string Group { get; set; }

        public int Priority { get; set; }

        public int Status { get; set; }

        public string Tags { get; set; }

        public int TimesRewRer { get; set; }

        public string Type { get; set; }

        public int RewRerValue { get; set; }

        public int Score { get; set; }
    }
}
