using Equipment.UseCases.Rooms.Dto;
using MediatR;

namespace Equipment.UseCases.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public RoomDto Dto { get; set; }
    }
}
