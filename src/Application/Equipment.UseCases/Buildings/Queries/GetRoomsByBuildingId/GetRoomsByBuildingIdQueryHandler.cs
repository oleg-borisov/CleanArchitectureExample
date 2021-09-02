using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Rooms.Dto;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Queries.GetRoomsByBuildingId
{
    public class GetRoomsByBuildingIdQueryHandler : IRequestHandler<GetRoomsByBuildingIdQuery, ICollection<RoomDto>>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public GetRoomsByBuildingIdQueryHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<ICollection<RoomDto>> Handle(GetRoomsByBuildingIdQuery request, CancellationToken cancellationToken)
        {
            var building = await dBContext.Buildings
                .AsNoTracking()
                .Include(x => x.Rooms)
                .SingleOrDefaultAsync(x => x.BuildingId == request.BuildingId);

            if (building == null)
            {
                throw new NotFoundException(nameof(Building), request.BuildingId);
            }
            
            var rooms = building.Rooms.ToList();

            var roomDtos = rooms.Select(mapper.Map<RoomDto>).ToList();
            return roomDtos;
        }
    }
}
