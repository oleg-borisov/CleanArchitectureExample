using FluentValidation;

namespace Equipment.UseCases.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateEquipmentTypeCommandValidator : AbstractValidator<UpdateEquipmentTypeCommand>
    {
        public UpdateEquipmentTypeCommandValidator()
        {
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.Name).Length(1, 255);
        }
    }
}
