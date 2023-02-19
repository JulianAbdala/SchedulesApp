using SchedulesApp.Classes.OverlapLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulesApp.Interfaces
{
    public interface IOverlapHandler
    {
        DayOfWeek Day { get; }
        DateTime StartTime { get; }
        DateTime EndTime { get; }

        TimeSpan CheckOverlap(OverlapHandler other);
    }

}
