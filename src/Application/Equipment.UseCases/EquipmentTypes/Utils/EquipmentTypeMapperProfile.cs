using AutoMapper;
using Equipment.Entities.Models;
using Equipment.UseCases.EquipmentTypes.Dto;

namespace Equipment.UseCases.EquipmentTypes.Utils
{
    public class EquipmentTypeMapperProfile : Profile
    {
        public EquipmentTypeMapperProfile()
        {
            CreateMap<EquipmentType, EquipmentTypeDto>().ReverseMap();
            CreateMap<CreateEquipmentTypeDto, EquipmentType>();
        }
    }
}
