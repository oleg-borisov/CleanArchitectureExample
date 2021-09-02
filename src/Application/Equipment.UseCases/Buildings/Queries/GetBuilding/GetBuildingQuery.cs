using Equipment.UseCases.Buildings.Dto;
using MediatR;

namespace Equipment.UseCases.Buildings.Queries.GetBuilding
{
    public class GetBuildingQuery : IRequest<BuildingDto>
    {
        public int Id { get; set; }
    }
}
