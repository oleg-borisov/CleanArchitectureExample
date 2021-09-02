using Equipment.ApplicationServices.Interfaces;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Queries.GetBuildingEquipmentIndicatorStatus
{
    public class GetBuildingEquipmentIndicatorStatusQueryHandler : IRequestHandler<GetBuildingEquipmentIndicatorStatusQuery, bool>
    {
        private readonly IDBContext dBContext;
        private readonly IEquipmentExistenceIndicatorApplicationService equipmentExistenceIndicatorApplicationService;

        public GetBuildingEquipmentIndicatorStatusQueryHandler(IDBContext dBContext, IEquipmentExistenceIndicatorApplicationService equipmentExistenceIndicatorApplicationService)
        {
            this.dBContext = dBContext;
            this.equipmentExistenceIndicatorApplicationService = equipmentExistenceIndicatorApplicationService;
        }

        public async Task<bool> Handle(GetBuildingEquipmentIndicatorStatusQuery request, CancellationToken cancellationToken)
        {
            var building = await dBContext.Buildings
                .AsNoTracking()
                .Include(x => x.Rooms)
                .ThenInclude(x => x.EquipmentItems)
                .SingleOrDefaultAsync(x => x.BuildingId == request.buildingId);

            if (building == null)
            {
                throw new NotFoundException(nameof(Building), request.buildingId);
            }

            var shouldShowIndicator = equipmentExistenceIndicatorApplicationService.ShouldShowIndicator(building);
            return shouldShowIndicator;
        }
    }
}
