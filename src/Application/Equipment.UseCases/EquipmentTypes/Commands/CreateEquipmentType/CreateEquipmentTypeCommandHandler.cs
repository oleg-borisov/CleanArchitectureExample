using AutoMapper;
using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.UseCases.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateEquipmentTypeCommandHandler : IRequestHandler<CreateEquipmentTypeCommand, int>
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;

        public CreateEquipmentTypeCommandHandler(IDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateEquipmentTypeCommand request, CancellationToken cancellationToken)
        {
            var equipmentType = mapper.Map<EquipmentType>(request.Dto);

            dBContext.EquipmentTypes.Add(equipmentType);
            await dBContext.SaveChangesAsync();

            return equipmentType.EquipmentTypeId;
        }
    }
}
