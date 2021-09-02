using Equipment.UseCases.EquipmentTypes.Dto;
using MediatR;

namespace Equipment.UseCases.EquipmentTypes.Queries.GetEquipmentType
{
    public class GetEquipmentTypeQuery : IRequest<EquipmentTypeDto>
    {
        public int Id { get; set; }
    }
}
