using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.UseCases.Buildings.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Queries.GetBuildingCollection
{
    public class GetBuildingCollectionQueryHandler : IRequestHandler<GetBuildingCollectionQuery, ICollection<BuildingDto>>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public GetBuildingCollectionQueryHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<ICollection<BuildingDto>> Handle(GetBuildingCollectionQuery request, CancellationToken cancellationToken)
        {
            var getBuildingsQuery = dBContext.Buildings
                .AsNoTracking();

            if (request.Offset.HasValue)
            {
                getBuildingsQuery = getBuildingsQuery.Skip(request.Offset.Value);
            }

            if (request.Length.HasValue)
            {
                getBuildingsQuery = getBuildingsQuery.Take(request.Length.Value);
            }

            var buildings = await getBuildingsQuery
                .ToListAsync();

            var buildingDtos = buildings.Select(mapper.Map<BuildingDto>).ToList();
            return buildingDtos;
        }
    }
}
