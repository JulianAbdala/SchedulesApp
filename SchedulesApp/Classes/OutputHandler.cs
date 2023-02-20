using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulesApp.Classes.OverlapLogic;
using SchedulesApp.Classes.ParsingLogic;
using SchedulesApp.Interfaces;

namespace SchedulesApp.Classes
{
    public class OutputHandler : IOutputHandler
    {
        public void Init(string inputFile)
        {
            //read the file and parses it
            InputParser inputParser = new InputParser();


            Dictionary<string, List<OverlapHandler>> employeeSchedules = inputParser.ReadInput(inputFile);

            //initiates the overlap logic
            OverlapCounter overlapCounter = new OverlapCounter();
            Dictionary<string, int> coincidencesList = overlapCounter.CreateOutputText(employeeSchedules);

            Console.WriteLine("List of employees with their respective overlaps among them: ");
            //creates output with the given coincidences
            foreach (KeyValuePair<string, int> coincidence in coincidencesList)
            {
                Console.WriteLine(coincidence.Key + " : " + coincidence.Value);
            }
        }
    }
}
