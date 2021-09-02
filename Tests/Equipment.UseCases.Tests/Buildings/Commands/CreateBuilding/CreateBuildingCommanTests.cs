using AutoMapper;
using Equipment.DataAccess.Implementation.MSSQL;
using Equipment.UseCases.Buildings.Commands;
using Equipment.UseCases.Buildings.Commands.CreateBuilding;
using Equipment.UseCases.Buildings.Dto;
using Equipment.UseCases.Tests.Utils;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading;
using Xunit;

namespace Equipment.UseCases.Tests.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommanTests : IClassFixture<CqrsTestFixture>
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public CreateBuildingCommanTests(CqrsTestFixture fixture)
        {
            this.context = fixture.ApplicationDBContext;
            this.mapper = fixture.Mapper;
        }

        [Fact]
        public async void ShouldCreateBuilding()
        {
            // Arrange
            var sut = new CreateBuildingCommandHandler(context, mapper);
            var createBuildingDto = new CreateBuildingDto
            {
                Name = "New building"
            };

            // Act
            var result = await sut.Handle(new CreateBuildingCommand { Dto = createBuildingDto }, CancellationToken.None);


            // Assert
            result.ShouldBePositive();
            var building = await context.Buildings.SingleOrDefaultAsync(x => x.BuildingId == result);
            building.ShouldNotBeNull();
            building.Name.ShouldBe("New building");
        }
    }
}
