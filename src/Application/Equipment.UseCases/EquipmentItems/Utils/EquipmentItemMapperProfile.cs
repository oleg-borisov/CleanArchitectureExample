using AutoMapper;
using Equipment.Entities.Models;
using Equipment.UseCases.EquipmentItems.Dto;

namespace Equipment.UseCases.EquipmentItems.Utils
{
    public class EquipmentItemMapperProfile : Profile
    {
        public EquipmentItemMapperProfile()
        {
            CreateMap<CreateEquipmentItemDto, EquipmentItem>();
            CreateMap<EquipmentItemDto, EquipmentItem>().ReverseMap();
        }
    }
}
