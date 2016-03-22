using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File and interface created code added    <-> 17.02.2016 : 14.30 +02.00 <-> Lolerji

*/


namespace DozzMaiMalApi.Entity.Essentials
{
    public interface IMalListEntity
    {
        // Everrything must have an ID!!
        int ID { get; set; }

        // Anime or Manga, Right??
        string Type { get; set; }

        // Downloaded eps/chaps
        int Downloaded { get; set; }

        // Times rewatched - rereead
        int TimesRewRer { get; set; } 

        int Score { get; set; }

        // Status
        int Status { get; set; }

        string DateStarted { get; set; }
        string DateFinished { get; set; }

        int Priority { get; set; }
        int EnableDisscussion { get; set; }
        int EnableRewRer { get; set; }
        int RewRerValue { get; set; }

        // Fansub group / Scan group
        string Group { get; set; }

        string Comments { get; set; }
        string Tags { get; set; }
    }
}
