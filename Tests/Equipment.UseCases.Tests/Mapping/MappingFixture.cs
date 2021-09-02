using AutoMapper;
using Equipment.UseCases.Buildings.Utils;

namespace Equipment.UseCases.Tests.Mapping
{
    public class MappingFixture
    {
        public MappingFixture()
        {
            ConfigurationProvider = new MapperConfiguration(x =>
            {
                x.AddProfile(typeof(BuildingMapperProfile));
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}
