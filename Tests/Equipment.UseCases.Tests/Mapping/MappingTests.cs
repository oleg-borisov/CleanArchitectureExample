using AutoMapper;
using Equipment.Entities.Models;
using Equipment.UseCases.Buildings.Dto;
using Shouldly;
using Xunit;

namespace Equipment.UseCases.Tests.Mapping
{
    public class MappingTests : IClassFixture<MappingFixture>
    {
        private readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public MappingTests(MappingFixture mappingFixture)
        {
            this.mapper = mappingFixture.Mapper;
            this.configuration = mappingFixture.ConfigurationProvider;
        }

        [Fact]
        void ShouldMapBuildingToBuildingDto()
        {
            var building = new Building();

            var buildingDto = mapper.Map<BuildingDto>(building);

            buildingDto.ShouldNotBeNull();
            buildingDto.ShouldBeOfType<BuildingDto>();
        }

        [Fact]
        void ShouldMapBuildingDtoToBuilding()
        {
            var buildingDto = new BuildingDto();

            var building = mapper.Map<Building>(buildingDto);

            building.ShouldNotBeNull();
            building.ShouldBeOfType<Building>();
        }
    }
}
