using Equipment.ApplicationServices.Interfaces;
using Equipment.Entities.Models;
using System.Linq;

namespace Equipment.ApplicationServices.Implementation
{
    // TODO: Move out to the ApplicationServices project
    public class EquipmentExistenceIndicatorApplicationService : IEquipmentExistenceIndicatorApplicationService
    {
        public bool ShouldShowIndicator(Building building)
        {
            var hasAnyEquipment = building.Rooms.Any(x => x.EquipmentItems.Any());
            return hasAnyEquipment;
        }

        public bool ShouldShowIndicator(Room room)
        {
            var hasAnyEquipment = room.EquipmentItems.Any();
            return hasAnyEquipment;
        }
    }
}
