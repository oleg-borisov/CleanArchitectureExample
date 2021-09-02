using Equipment.ApplicationServices.Interfaces;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Rooms.Queries.GetRoomEquipmentIndicatorStatus
{
    public class GetRoomEquipmentIndicatorStatusQueryHandler : IRequestHandler<GetRoomEquipmentIndicatorStatusQuery, bool>
    {
        private readonly IDBContext dBContext;
        private readonly IEquipmentExistenceIndicatorApplicationService equipmentExistenceIndicatorApplicationService;

        public GetRoomEquipmentIndicatorStatusQueryHandler(IDBContext dBContext, IEquipmentExistenceIndicatorApplicationService equipmentExistenceIndicatorApplicationService)
        {
            this.dBContext = dBContext;
            this.equipmentExistenceIndicatorApplicationService = equipmentExistenceIndicatorApplicationService;
        }

        public async Task<bool> Handle(GetRoomEquipmentIndicatorStatusQuery request, CancellationToken cancellationToken)
        {
            var room = await dBContext.Rooms
                .AsNoTracking()
                .Include(x => x.EquipmentItems)
                .SingleOrDefaultAsync(x => x.RoomId == request.RoomId);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var showShowIndicator = equipmentExistenceIndicatorApplicationService.ShouldShowIndicator(room);
            return showShowIndicator;
        }
    }
}
