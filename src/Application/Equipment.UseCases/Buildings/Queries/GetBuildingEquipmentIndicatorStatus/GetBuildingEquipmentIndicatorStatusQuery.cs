using MediatR;

namespace Equipment.UseCases.Buildings.Queries.GetBuildingEquipmentIndicatorStatus
{
    public class GetBuildingEquipmentIndicatorStatusQuery : IRequest<bool>
    {
        public int buildingId { get; set; }
    }
}
