using SchedulesApp.Classes.OverlapLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulesApp.Interfaces
{
    public interface IInputParser
    {
        Dictionary<string, List<OverlapHandler>> ReadInput(string inputFile);
    }

}
