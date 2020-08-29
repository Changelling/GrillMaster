using GrillMaster.Application.GrillMenu.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrillMaster.Application.GrillMenu.Commands.CalculateSchedule
{
    public class CalculateScheduleCommand : IRequest<GrillPlanning>
    {
        public IEnumerable<Domain.Entities.GrillMenu> Menus { get; set; }
        public Size GrillMeasure { get; set; }
    }

    public class CalculateScheduleCommandHandler : IRequestHandler<CalculateScheduleCommand, GrillPlanning>
    {
        private readonly IGrillCalculator _calculator;

        public CalculateScheduleCommandHandler(IGrillCalculator calculator)
        {
            _calculator = calculator;
        }

        public async Task<GrillPlanning> Handle(CalculateScheduleCommand request, CancellationToken cancellationToken)
        {
            GrillPlanning grillPlanning = new GrillPlanning();
            foreach (var menu in request.Menus)
            {
                MenuPlanning menuPlanning = await _calculator.Calculate(menu, request.GrillMeasure);                
                grillPlanning.Menus.Add(menuPlanning);
            }
            return grillPlanning;
        }
    }
}
