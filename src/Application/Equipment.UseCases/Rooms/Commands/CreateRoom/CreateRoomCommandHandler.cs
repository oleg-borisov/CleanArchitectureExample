using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public CreateRoomCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var building = await dBContext.Buildings
                .Include(x => x.Rooms)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.BuildingId == request.BuildingId);

            if (building == null)
            {
                throw new NotFoundException(nameof(Building), request.BuildingId);
            }

            var room = mapper.Map<Room>(request.Dto);
            room.BuildingId = building.BuildingId;
            dBContext.Rooms.Add(room);
            await dBContext.SaveChangesAsync();

            return room.RoomId;
        }
    }
}
