using Equipment.Entities.Models;

namespace Equipment.ApplicationServices.Interfaces
{
    public interface IEquipmentExistenceIndicatorApplicationService
    {
        bool ShouldShowIndicator(Building building);

        bool ShouldShowIndicator(Room room);
    }
}
