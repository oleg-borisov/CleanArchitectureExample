using FluentValidation;

namespace Equipment.UseCases.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator: AbstractValidator<UpdateRoomCommand> 
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.BuildingId).GreaterThan(0);
            RuleFor(x => x.Dto.RoomId).GreaterThan(0);
            RuleFor(x => x.Dto.Name).Length(1, 255);
        }
    }
}
