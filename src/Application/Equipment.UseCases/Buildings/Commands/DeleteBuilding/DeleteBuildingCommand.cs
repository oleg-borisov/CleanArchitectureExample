using MediatR;

namespace Equipment.UseCases.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommand: IRequest
    {
        public int Id { get; set; }
    }
}
