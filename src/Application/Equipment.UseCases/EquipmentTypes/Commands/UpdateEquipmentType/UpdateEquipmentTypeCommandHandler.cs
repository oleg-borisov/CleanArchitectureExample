using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateEquipmentTypeCommandHandler : IRequestHandler<UpdateEquipmentTypeCommand, Unit>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public UpdateEquipmentTypeCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEquipmentTypeCommand request, CancellationToken cancellationToken)
        {
            var hasFound = await dBContext.EquipmentTypes
                .AsNoTracking()
                .AnyAsync(x => x.EquipmentTypeId == request.Dto.EquipmentTypeId);

            if (!hasFound)
            {
                throw new NotFoundException(nameof(EquipmentType), request.Dto.EquipmentTypeId);
            }

            var equipmentType = mapper.Map<EquipmentType>(request.Dto);
            dBContext.EquipmentTypes.Update(equipmentType);

            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
