using Equipment.UseCases.Buildings.Dto;
using MediatR;
using System.Collections.Generic;

namespace Equipment.UseCases.Buildings.Queries.GetBuildingCollection
{
    public class GetBuildingCollectionQuery : IRequest<ICollection<BuildingDto>>
    {
    }
}
