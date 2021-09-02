using FluentValidation;

namespace Equipment.UseCases.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
    {
        public CreateBuildingCommandValidator()
        {
            RuleFor(x => x.Dto.Name).Length(1, 255);
        }
    }
}
