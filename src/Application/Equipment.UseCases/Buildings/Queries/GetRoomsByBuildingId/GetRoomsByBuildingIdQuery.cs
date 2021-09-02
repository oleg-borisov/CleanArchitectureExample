using Equipment.UseCases.Rooms.Dto;
using MediatR;
using System.Collections.Generic;

namespace Equipment.UseCases.Buildings.Queries.GetRoomsByBuildingId
{
    public class GetRoomsByBuildingIdQuery : IRequest<ICollection<RoomDto>>
    {
        public int BuildingId { get; set; }
    }
}
