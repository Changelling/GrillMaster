using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Application.GrillMenu.Commands.CalculateSchedule
{
    public class MenuPlanning
    {
        public string Name { get; set; }
        public int Rounds { get; set; }
        public IEnumerable<string> Order { get; set; }
    }
}
