using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.EquipmentTypes.Dto;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.EquipmentTypes.Queries.GetEquipmentType
{
    public class GetEquipmentTypeQueryHandler : IRequestHandler<GetEquipmentTypeQuery, EquipmentTypeDto>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public GetEquipmentTypeQueryHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<EquipmentTypeDto> Handle(GetEquipmentTypeQuery request, CancellationToken cancellationToken)
        {
            var equipmentType = await dBContext.EquipmentTypes
             .AsNoTracking()
             .SingleOrDefaultAsync(x => x.EquipmentTypeId == request.Id);

            if (equipmentType == null)
            {
                throw new NotFoundException(nameof(EquipmentType), request.Id);
            }

            var equipmentTypeDto = mapper.Map<EquipmentTypeDto>(equipmentType);
            return equipmentTypeDto;
        }
    }
}
