using Equipment.UseCases.EquipmentItems.Dto;
using MediatR;
using System.Collections.Generic;

namespace Equipment.UseCases.Rooms.Queries.GetViewEquipmentItems
{
    public class GetViewEquipmentItemsQuery : IRequest<ICollection<ViewEquipmentItemDto>>
    {
        public int RoomId { get; set; }
    }
}
