using Equipment.UseCases.EquipmentTypes.Dto;
using MediatR;
using System.Collections.Generic;

namespace Equipment.UseCases.EquipmentTypes.Queries.GetEquipmentTypeCollection
{
    public class GetEquipmentTypeCollectionQuery : IRequest<ICollection<EquipmentTypeDto>>
    {
    }
}
