using AutoMapper;
using GrillMaster.Application.GrillMenu.Commands.CalculateSchedule;
using GrillMaster.Domain.Entities;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using GrillMaster.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.Services
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism for calculating the optimal time for grilling
    /// </summary>
    public class GrillCalculatorService : IGrillCalculator
    {
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public GrillCalculatorService(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtains the optimum planning for grilling whole menu.
        /// </summary>
        public async Task<MenuPlanning> Calculate(GrillMenu menu, Size grillSize)
        {
            MenuPlanning planning = new MenuPlanning() { Name = menu.Menu};
            List<MenuItemDto> items = AsMenuItemDto(menu.Items);
            var binPack = (IBinPack)_serviceProvider.GetService(typeof(IBinPack));
            binPack.Init(grillSize.Width, grillSize.Height);
            var bins = await binPack.Pack(items);
            planning.Rounds = bins.Count();
            planning.Order = bins.SelectMany(b => b.UsedSpaces.OfType<MenuItemDto>().Select(s => s.Name));
            return planning;
        }

        private List<MenuItemDto> AsMenuItemDto(IList<GrillMenuItem> items)
        {
            List<MenuItemDto> dtos = new List<MenuItemDto>();
            foreach (var item in items)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    dtos.Add(_mapper.Map<GrillMenuItem, MenuItemDto>(item));
                }
            }
            return dtos;
        }
    }
}
