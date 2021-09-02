using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Buildings.Dto;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Queries.GetBuilding
{
    public class GetBuildingQueryHandler : IRequestHandler<GetBuildingQuery, BuildingDto>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public GetBuildingQueryHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<BuildingDto> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
        {
            var building = await dBContext.Buildings
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.BuildingId == request.Id);
            if (building == null)
            {
                throw new NotFoundException(nameof(Building), request.Id);
            }

            var buildingDto = mapper.Map<BuildingDto>(building);

            return buildingDto;
        }
    }
}
