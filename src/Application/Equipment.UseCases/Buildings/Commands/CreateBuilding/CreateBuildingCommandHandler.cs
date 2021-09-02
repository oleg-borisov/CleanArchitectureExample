using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, int>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public CreateBuildingCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = mapper.Map<Building>(request.Dto);
            dBContext.Buildings.Add(building);
            await dBContext.SaveChangesAsync();
            return building.BuildingId;
        }
    }
}
