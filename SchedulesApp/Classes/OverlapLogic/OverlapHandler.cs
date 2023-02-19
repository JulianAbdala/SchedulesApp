
using SchedulesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulesApp.Classes.OverlapLogic
{

    public class OverlapHandler : IOverlapHandler
    {
        public DayOfWeek Day { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public OverlapHandler(DayOfWeek day, DateTime startTime, DateTime endTime)
        {
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
        }

        //checks overlaps between schedules and then outputs a "timespan" variable called 'overlap'
        public TimeSpan CheckOverlap(OverlapHandler other)
        {

            if (EndTime <= other.StartTime || StartTime >= other.EndTime)
            {
                return TimeSpan.Zero;
            }

            DateTime overlapStart = StartTime > other.StartTime ? StartTime : other.StartTime;
            DateTime overlapEnd = EndTime < other.EndTime ? EndTime : other.EndTime;
            TimeSpan overlap = overlapEnd - overlapStart;

            return overlap;
        }

    }
}
