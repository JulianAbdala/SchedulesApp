
using SchedulesApp.Classes.OverlapLogic;
using SchedulesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchedulesApp.Classes.ParsingLogic
{
    public class InputParser 
    {

        public Dictionary<string, List<OverlapHandler>> ReadInput(string inputFile)
        {

            Dictionary<string, List<OverlapHandler>> employeeSchedules = new Dictionary<string, List<OverlapHandler>>();
            //StreamReader function process the file
            using (StreamReader reader = new StreamReader(inputFile))
            {   //I divide the code line by line, separating data by their symbols
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('=');
                    string employeeName = data[0];
                    string[] scheduleData = data[1].Split(',');

                    List<OverlapHandler> schedule = new List<OverlapHandler>();
                    foreach (string daySchedule in scheduleData)
                    {
                        //I had to add a "_" to separate days from hours, i couldn't find a way to do it without it
                        string[] dayParts = daySchedule.Split('_');
                        DayOfWeek day = ParseDayOfWeek(dayParts[0]);
                        string[] timeParts = dayParts[1].Split('-');
                        DateTime startTime = DateTime.Parse(timeParts[0]);
                        DateTime endTime = DateTime.Parse(timeParts[1]);
                        OverlapHandler overlapHandler = new OverlapHandler(day, startTime, endTime);
                        schedule.Add(overlapHandler);
                    }
                    employeeSchedules.Add(employeeName, schedule);
                }
            }

            return employeeSchedules;
        }

        //checks that the day of the week exists and parses it using the DayOfWeek function
        public DayOfWeek ParseDayOfWeek(string day) => day switch
        {
            "MO" => DayOfWeek.Monday,
            "TU" => DayOfWeek.Tuesday,
            "WE" => DayOfWeek.Wednesday,
            "TH" => DayOfWeek.Thursday,
            "FR" => DayOfWeek.Friday,
            "SA" => DayOfWeek.Saturday,
            "SU" => DayOfWeek.Sunday,
            _ => throw new ArgumentException("Incorrect day: " + day)
        };


    }
}
