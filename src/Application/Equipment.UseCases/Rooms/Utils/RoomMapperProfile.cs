using AutoMapper;
using Equipment.Entities.Models;
using Equipment.UseCases.Rooms.Dto;

namespace Equipment.UseCases.Rooms.Utils
{
    public class RoomMapperProfile : Profile
    {
        public RoomMapperProfile()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<CreateRoomDto, Room>();
        }
    }
}
