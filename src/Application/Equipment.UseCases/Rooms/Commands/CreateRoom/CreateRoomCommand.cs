using Equipment.UseCases.Rooms.Dto;
using MediatR;

namespace Equipment.UseCases.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<int>
    {
        public int BuildingId { get; set; }

        public CreateRoomDto Dto { get; set; }
    }
}
