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

namespace Equipment.UseCases.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public DeleteRoomCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await dBContext.Rooms
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.RoomId == request.Id);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            dBContext.Rooms.Remove(room);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
