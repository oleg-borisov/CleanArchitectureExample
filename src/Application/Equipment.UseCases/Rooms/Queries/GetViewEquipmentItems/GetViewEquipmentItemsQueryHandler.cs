using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.EquipmentItems.Dto;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Rooms.Queries.GetViewEquipmentItems
{
    public class GetViewEquipmentItemsQueryHandler : IRequestHandler<GetViewEquipmentItemsQuery, ICollection<ViewEquipmentItemDto>>
    {
        private readonly IDBContext dBContext;

        public GetViewEquipmentItemsQueryHandler(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<ICollection<ViewEquipmentItemDto>> Handle(GetViewEquipmentItemsQuery request, CancellationToken cancellationToken)
        {
            var room = await dBContext.Rooms
                .AsNoTracking()
                .Include(x => x.EquipmentItems)
                .ThenInclude(x => x.EquipmentType)
                .SingleOrDefaultAsync(x => x.RoomId == request.RoomId);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var equipmentItems = room.EquipmentItems
                .Select(x => new ViewEquipmentItemDto
                {
                    EquipmentTypeId = x.EquipmentTypeId,
                    Name = x.EquipmentType.Name,
                    Quantity = x.Quantity
                })
                .ToList();

            return equipmentItems;
        }
    }
}
