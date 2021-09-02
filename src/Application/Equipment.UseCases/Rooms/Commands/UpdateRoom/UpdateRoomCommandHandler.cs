using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public UpdateRoomCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var hasFound = await dBContext.Rooms
                .AsNoTracking()
                .AnyAsync(x => x.RoomId == request.Dto.RoomId);

            if (!hasFound)
            {
                throw new NotFoundException(nameof(Room), request.Dto.RoomId);
            }

            var room = mapper.Map<Room>(request.Dto);
            dBContext.Rooms.Update(room);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
