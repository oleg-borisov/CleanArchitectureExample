using Equipment.UseCases.EquipmentItems.Dto;
using MediatR;

namespace Equipment.UseCases.EquipmentItems.Commands.CreateEquipmentItem
{
    public class CreateEquipmentItemCommand : IRequest
    {
        public int RoomId { get; set; }

        public CreateEquipmentItemDto Dto { get; set; }
    }
}
