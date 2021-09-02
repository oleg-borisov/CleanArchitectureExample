using Equipment.UseCases.EquipmentTypes.Dto;
using MediatR;

namespace Equipment.UseCases.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateEquipmentTypeCommand : IRequest<int>
    {
        public CreateEquipmentTypeDto Dto { get; set; }
    }
}
