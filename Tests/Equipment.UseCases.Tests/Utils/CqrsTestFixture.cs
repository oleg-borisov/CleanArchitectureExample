using AutoMapper;
using Equipment.DataAccess.Implementation.MSSQL;
using Equipment.UseCases.Buildings.Utils;
using System;

namespace Equipment.UseCases.Tests.Utils
{
    public class CqrsTestFixture : IDisposable
    {
        public CqrsTestFixture()
        {
            ApplicationDBContext = ApplicationContextFactory.Create();
            ConfigurationProvider = new MapperConfiguration(x =>
            {
                x.AddProfile(typeof(BuildingMapperProfile));
            });
            Mapper = ConfigurationProvider.CreateMapper();
        }

        public ApplicationDBContext ApplicationDBContext { get; }

        public IMapper Mapper { get; }

        public IConfigurationProvider ConfigurationProvider { get; }

        public void Dispose()
        {
            ApplicationDBContext.Dispose();
        }
    }
}
