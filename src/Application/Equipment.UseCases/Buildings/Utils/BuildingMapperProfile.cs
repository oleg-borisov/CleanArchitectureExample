using AutoMapper;
using Equipment.Entities.Models;
using Equipment.UseCases.Buildings.Dto;

namespace Equipment.UseCases.Buildings.Utils
{
    public class BuildingMapperProfile : Profile
    {
        public BuildingMapperProfile()
        {
            CreateMap<CreateBuildingDto, Building>();
            CreateMap<BuildingDto, Building>().ReverseMap();
        }
    }
}
