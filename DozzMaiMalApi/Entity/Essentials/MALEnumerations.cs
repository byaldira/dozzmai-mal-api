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
}
