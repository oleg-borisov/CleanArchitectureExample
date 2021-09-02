using Equipment.UseCases.EquipmentItems.Dto;
using MediatR;
using System.Collections.Generic;

namespace Equipment.UseCases.Buildings.Queries.GetSummaryViewEquipmentItems
{
    public class GetSummaryViewEquipmentItemsQuery : IRequest<ICollection<SummaryViewEquipmentItemDto>>
    {
        public int BuildingId { get; set; }
    }
}
