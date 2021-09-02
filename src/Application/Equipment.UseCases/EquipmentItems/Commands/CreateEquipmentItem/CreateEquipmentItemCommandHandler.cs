using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.EquipmentItems.Commands.CreateEquipmentItem
{
    public class CreateEquipmentItemCommandHandler : IRequestHandler<CreateEquipmentItemCommand, Unit>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public CreateEquipmentItemCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateEquipmentItemCommand request, CancellationToken cancellationToken)
        {
            var room = await dBContext.Rooms
                .Include(x => x.EquipmentItems)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.RoomId == request.RoomId);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var equipmentItem = mapper.Map<EquipmentItem>(request.Dto);
            var alreadyExists = room.EquipmentItems.Any(x => x.EquipmentTypeId == equipmentItem.EquipmentTypeId);

            if (alreadyExists)
            {
                throw new ConflictException($"{nameof(EquipmentType)} ({equipmentItem.EquipmentTypeId}) has already been existed in a {nameof(Room)} ({room.RoomId})");
            }

            equipmentItem.RoomId = room.RoomId;
            dBContext.EquipmentItems.Add(equipmentItem);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
