using AutoMapper;
using GrillMaster.Application.Common.Mappings;
using GrillMaster.Domain.Entities;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GrillMaster.Infrastructure.Entities
{
    /// <summary>
    /// Resumen:
    ///     Defines an menu item that can be packed.
    /// </summary>
    public class MenuItemDto : IItem, IMapFrom<GrillMenuItem>
    {
        public int sId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public TimeSpan Duration { get; set; }
        public int Quantity { get; set; }
        public Rectangle Rectangle { get; set; }
    }
}
