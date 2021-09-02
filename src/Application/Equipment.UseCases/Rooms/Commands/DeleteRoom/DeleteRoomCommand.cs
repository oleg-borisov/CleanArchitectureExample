using MediatR;

namespace Equipment.UseCases.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
