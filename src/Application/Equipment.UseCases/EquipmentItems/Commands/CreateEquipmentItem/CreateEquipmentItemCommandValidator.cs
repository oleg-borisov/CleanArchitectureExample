using Equipment.UseCases.EquipmentItems.Commands.CreateEquipmentItem;
using FluentValidation;

namespace Equipment.UseCases.EquipmentItems.Commands.CreateRoom
{
    public class CreateEquipmentItemCommandValidator : AbstractValidator<CreateEquipmentItemCommand>
    {
        public CreateEquipmentItemCommandValidator()
        {
            RuleFor(x => x.RoomId).GreaterThan(0);
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.Quantity).GreaterThan(0);
        }
    }
}
