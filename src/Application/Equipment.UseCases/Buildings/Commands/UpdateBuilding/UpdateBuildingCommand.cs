using Equipment.UseCases.Buildings.Dto;
using MediatR;

namespace Equipment.UseCases.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommand: IRequest
    {
        public BuildingDto Dto { get; set; }
    }
}
