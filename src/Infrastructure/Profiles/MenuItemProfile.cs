using AutoMapper;
using GrillMaster.Domain.Entities;
using GrillMaster.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GrillMaster.Infrastructure.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<GrillMenuItem, MenuItemDto>()
                    .ForMember(dest => dest.Rectangle,
                    opt => opt.MapFrom(src => new Rectangle(0, 0, src.Width, src.Length)));

        }
    }
}
