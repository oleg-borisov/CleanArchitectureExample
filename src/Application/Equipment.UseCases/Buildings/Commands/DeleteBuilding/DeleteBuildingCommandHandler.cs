using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand>
    {
        private readonly IDBContext dBContext;

        public DeleteBuildingCommandHandler(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await dBContext.Buildings
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.BuildingId == request.Id);

            if (building == null)
            {
                throw new NotFoundException(nameof(Building), request.Id);
            }

            dBContext.Buildings.Remove(building);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
