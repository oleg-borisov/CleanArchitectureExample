using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.UseCases.EquipmentTypes.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.EquipmentTypes.Queries.GetEquipmentTypeCollection
{
    public class GetEquipmentTypeCollectionQueryHandler : IRequestHandler<GetEquipmentTypeCollectionQuery, ICollection<EquipmentTypeDto>>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public GetEquipmentTypeCollectionQueryHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<ICollection<EquipmentTypeDto>> Handle(GetEquipmentTypeCollectionQuery request, CancellationToken cancellationToken)
        {
            var equipmentTypes = await dBContext.EquipmentTypes
                .AsNoTracking()
                .ToListAsync();

            var equipmentTypeDtos = equipmentTypes.Select(mapper.Map<EquipmentTypeDto>).ToList();
            return equipmentTypeDtos;
        }
    }
}
