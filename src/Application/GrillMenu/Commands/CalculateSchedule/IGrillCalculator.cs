using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Application.GrillMenu.Commands.CalculateSchedule
{
    public interface IGrillCalculator
    {
        Task<MenuPlanning> Calculate(Domain.Entities.GrillMenu menu, Size grillSize);
    }
}
