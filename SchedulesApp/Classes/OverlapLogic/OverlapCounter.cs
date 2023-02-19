using SchedulesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulesApp.Classes.OverlapLogic
{
    public class OverlapCounter
    {
        public int CountOverlaps(List<OverlapHandler> schedule1, List<OverlapHandler> schedule2)
        {
            int overlaps = 0;

            foreach (OverlapHandler range1 in schedule1)
            {
                foreach (OverlapHandler range2 in schedule2)
                {
                    if (range1.Day != range2.Day)
                    {
                        continue;
                    }
                    //calls function checkoverlap to sum an overlap if it exists
                    TimeSpan overlap = range1.CheckOverlap(range2);
                    if (overlap != TimeSpan.Zero)
                    {
                        overlaps++;
                    }
                }
            }

            return overlaps;
        }
        //Here i declare a method called 'CreateOutputText' that calls a dictionary with the name and listed schedules
        public Dictionary<string, int> CreateOutputText(Dictionary<string, List<OverlapHandler>> employeeSchedules)
        {
            Dictionary<string, int> coincidencesList = new Dictionary<string, int>();
            //I use names as keys to safely iterate between the nested dictionaries of employees
            foreach (KeyValuePair<string, List<OverlapHandler>> firstEmployee in employeeSchedules)
            {
                string employee1 = firstEmployee.Key;
                List<OverlapHandler> schedule1 = firstEmployee.Value;
                foreach (KeyValuePair<string, List<OverlapHandler>> secondEmployee in employeeSchedules)
                {
                    string employee2 = secondEmployee.Key;
                    List<OverlapHandler> schedule2 = secondEmployee.Value;
                    //if iterated employees are equal or if they are already counted this functions skips them
                    if (employee1 == employee2 || coincidencesList.ContainsKey(employee2 + " - " + employee1))
                    {
                        continue;
                    }

                    int coincidences = CountOverlaps(schedule1, schedule2);

                    coincidencesList.Add(employee1 + " - " + employee2, coincidences);
                }
            }

            return coincidencesList;
        }
    }
}
