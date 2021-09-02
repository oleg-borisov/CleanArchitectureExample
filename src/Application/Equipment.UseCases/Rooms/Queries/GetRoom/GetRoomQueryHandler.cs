using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Rooms.Dto;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Rooms.Queries.GetRoom
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomDto>
    {
        private readonly IDBContext dbContext;
        private readonly IMapper mapper;

        public GetRoomQueryHandler(IDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<RoomDto> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await dbContext.Rooms
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.RoomId == request.Id);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            var roomDto = mapper.Map<RoomDto>(room);
            return roomDto;
        }
    }
}
