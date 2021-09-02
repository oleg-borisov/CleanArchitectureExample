using Equipment.UseCases.Rooms.Dto;
using MediatR;

namespace Equipment.UseCases.Rooms.Queries.GetRoom
{
    public class GetRoomQuery: IRequest<RoomDto>
    {
        public int Id { get; set; }
    }
}
