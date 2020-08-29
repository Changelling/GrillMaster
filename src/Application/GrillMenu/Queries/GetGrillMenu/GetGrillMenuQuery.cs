using GrillMaster.Application.GrillMenu.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrillMaster.Application.GrillMenu.Queries.GetGrillMenu
{
    public class GetGrillMenuQuery : IRequest<IEnumerable<Domain.Entities.GrillMenu>>
    {
    }

    public class GetGrillMenuQueryHandler : IRequestHandler<GetGrillMenuQuery, IEnumerable<Domain.Entities.GrillMenu>>
    {
        private readonly IGrillMenuClient _menuClient;

        public GetGrillMenuQueryHandler(IGrillMenuClient menuClient)
        {
            _menuClient = menuClient;
        }

        public async Task<IEnumerable<Domain.Entities.GrillMenu>> Handle(GetGrillMenuQuery request, CancellationToken cancellationToken)
        {
            return await _menuClient.GetAll();
        }
    }
}
