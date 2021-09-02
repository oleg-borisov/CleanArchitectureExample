using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Equipment.UseCases.Utils.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.EquipmentTypes.Commands.DeleteEquipmentType
{
    public class DeleteEquipmentTypeCommandHandler : IRequestHandler<DeleteEquipmentTypeCommand, Unit>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public DeleteEquipmentTypeCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEquipmentTypeCommand request, CancellationToken cancellationToken)
        {
            var equipmentType = await dBContext.EquipmentTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.EquipmentTypeId == request.Id);

            if (equipmentType == null)
            {
                throw new NotFoundException(nameof(EquipmentType), request.Id);
            }

            dBContext.EquipmentTypes.Remove(equipmentType);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
