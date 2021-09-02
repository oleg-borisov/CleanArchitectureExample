using Equipment.UseCases.Buildings.Dto;
using MediatR;

namespace Equipment.UseCases.Buildings.Commands
{
    public class CreateBuildingCommand : IRequest<int>
    {
        public CreateBuildingDto Dto { get; set; }
    }
}
