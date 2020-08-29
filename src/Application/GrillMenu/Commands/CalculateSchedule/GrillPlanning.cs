using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrillMaster.Application.GrillMenu.Commands.CalculateSchedule
{
    public class GrillPlanning
    {
        public GrillPlanning()
        {
            Menus = new List<MenuPlanning>();
        }

        public int TotalRounds { 
            get => Menus.Sum(m => m.Rounds);            
        }

        public IList<MenuPlanning> Menus { get; set; }
    }
}
