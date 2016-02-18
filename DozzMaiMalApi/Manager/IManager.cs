using DozzMaiMalApi.Entity.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    
    UPDATES MADE:
        
        // Update Description \\    // Update Date \\   // Updater (Use github or mal user name) \\

    -> File and interface created code added    <-> 17.02.2016 : 15.10 +02.00 <-> Lolerji

*/


namespace DozzMaiMalApi.Manager
{
    public interface IManager
    {
        void Add(IMalListEntity iMalEntity);
        void Update(IMalListEntity iMalEntity);
        void Delete(IMalListEntity iMalEntity);
    }
}
