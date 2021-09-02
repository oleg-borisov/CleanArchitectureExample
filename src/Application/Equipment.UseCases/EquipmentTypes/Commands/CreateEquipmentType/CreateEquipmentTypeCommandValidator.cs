using FluentValidation;

namespace Equipment.UseCases.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateEquipmentTypeCommandValidator : AbstractValidator<CreateEquipmentTypeCommand>
    {
        public CreateEquipmentTypeCommandValidator()
        {
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.Name).Length(0, 255);
        }
    }
}
