using MediatR;

namespace Equipment.UseCases.Rooms.Queries.GetRoomEquipmentIndicatorStatus
{
    public class GetRoomEquipmentIndicatorStatusQuery : IRequest<bool>
    {
        public int RoomId { get; set; }
    }
}
