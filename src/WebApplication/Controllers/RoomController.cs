using Equipment.UseCases.EquipmentItems.Commands.CreateEquipmentItem;
using Equipment.UseCases.EquipmentItems.Dto;
using Equipment.UseCases.Rooms.Commands.DeleteRoom;
using Equipment.UseCases.Rooms.Commands.UpdateRoom;
using Equipment.UseCases.Rooms.Dto;
using Equipment.UseCases.Rooms.Queries.GetRoom;
using Equipment.UseCases.Rooms.Queries.GetRoomEquipmentIndicatorStatus;
using Equipment.UseCases.Rooms.Queries.GetViewEquipmentItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoomController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<RoomDto>>> GetAsync(int id)
        {
            var roomDto = await mediator.Send(new GetRoomQuery { Id = id });

            return Ok(roomDto);
        }

        [HttpGet("{id}/equipmentItems")]
        public async Task<ActionResult<ICollection<ViewEquipmentItemDto>>> GetEquipmentItemsAsync(int id)
        {
            var viewEquipmentItemDtos = await mediator.Send(new GetViewEquipmentItemsQuery { RoomId = id });

            return Ok(viewEquipmentItemDtos);
        }

        [HttpPost("{id}/equipmentItems")]
        public async Task<ActionResult> PostEquipmentItemAsync(int id, [FromBody]CreateEquipmentItemDto createEquipmentItemDto)
        {
            await mediator.Send(new CreateEquipmentItemCommand { RoomId = id, Dto = createEquipmentItemDto });

            // TODO: Create controller for EquipmentItem
            return Created("", null);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] RoomDto roomDto)
        {
            await mediator.Send(new UpdateRoomCommand { Dto = roomDto });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await mediator.Send(new DeleteRoomCommand { Id = id });

            return NoContent();
        }
    }
}
