using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozzMaiMalApi.Entity.Essentials
{
    public enum MALAninmeTypes
    {
        TVSeries = 0,
        OVA,
        ONA,
        Movie,
        Special
    }

    public enum MALStatus
    {
        NotYetAired = 0,
        CurrentlyAiring,
        Finished
    }

    public enum MALListStatus
    {
        Watching = 1,
        Completed = 2,
        OnHold = 3,
        Dropped = 4,
        PlanToWatch = 6,
        All = 7
    }

    public enum MALType
    {
        Anime,
        Manga
    }
}
