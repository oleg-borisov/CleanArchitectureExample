using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public UpdateBuildingCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var hasFound = await dBContext.Buildings
                .AsNoTracking()
                .AnyAsync(x => x.BuildingId == request.Dto.BuildingId);

            if (!hasFound)
            {
                throw new NotFoundException(nameof(Building), request.Dto.BuildingId);
            }

            var building = mapper.Map<Building>(request.Dto);
            dBContext.Buildings.Update(building);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
