using GrillMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Application.GrillMenu.Interfaces
{
    public interface IGrillMenuClient
    {
        Task<IEnumerable<Domain.Entities.GrillMenu>> GetAll();
    }
}
