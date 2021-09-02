using FluentValidation;

namespace Equipment.UseCases.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandValidator : AbstractValidator<UpdateBuildingCommand>
    {
        public UpdateBuildingCommandValidator()
        {
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.Name).Length(1, 255);
        }
    }
}
