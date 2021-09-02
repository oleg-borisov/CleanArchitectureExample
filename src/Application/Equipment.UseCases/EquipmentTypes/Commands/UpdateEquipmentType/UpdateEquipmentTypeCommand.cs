using Equipment.UseCases.EquipmentTypes.Dto;
using MediatR;

namespace Equipment.UseCases.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateEquipmentTypeCommand : IRequest
    {
        public EquipmentTypeDto Dto { get; set; }
    }
}
