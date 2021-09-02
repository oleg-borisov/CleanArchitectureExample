using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.EquipmentItems.Dto;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.Buildings.Queries.GetSummaryViewEquipmentItems
{
    public class GetSummaryViewEquipmentItemsQueryHandler : IRequestHandler<GetSummaryViewEquipmentItemsQuery, ICollection<SummaryViewEquipmentItemDto>>
    {
        private readonly IDBContext dBContext;

        public GetSummaryViewEquipmentItemsQueryHandler(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<ICollection<SummaryViewEquipmentItemDto>> Handle(GetSummaryViewEquipmentItemsQuery request, CancellationToken cancellationToken)
        {
            var building = await dBContext.Buildings
                .AsNoTracking()
                .Include(x => x.Rooms)
                .ThenInclude(x => x.EquipmentItems)
                .ThenInclude(x => x.EquipmentType)
                .SingleOrDefaultAsync(x => x.BuildingId == request.BuildingId);

            if (building == null)
            {
                throw new NotFoundException(nameof(Building), request.BuildingId);
            }

            var equipmentItems = building.Rooms
                .SelectMany(x => x.EquipmentItems)
                .GroupBy(x => x.EquipmentType.Name)
                .Select(x => new SummaryViewEquipmentItemDto
                {
                    Name = x.Key,
                    Quantity = x.Sum(l => l.Quantity)
                })
                .ToList();

            return equipmentItems;
        }
    }
}
