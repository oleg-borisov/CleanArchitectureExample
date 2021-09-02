using FluentValidation;

namespace Equipment.UseCases.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.BuildingId).GreaterThan(0);
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.Name).Length(1, 255);
        }
    }
}
