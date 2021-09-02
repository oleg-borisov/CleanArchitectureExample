using MediatR;

namespace Equipment.UseCases.EquipmentTypes.Commands.DeleteEquipmentType
{
    public class DeleteEquipmentTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
