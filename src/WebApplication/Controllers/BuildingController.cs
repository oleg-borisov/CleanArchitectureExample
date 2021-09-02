using Equipment.UseCases.Buildings.Commands;
using Equipment.UseCases.Buildings.Commands.DeleteBuilding;
using Equipment.UseCases.Buildings.Commands.UpdateBuilding;
using Equipment.UseCases.Buildings.Dto;
using Equipment.UseCases.Buildings.Queries.GetBuildingCollection;
using Equipment.UseCases.Buildings.Queries.GetBuilding;
using Equipment.UseCases.Buildings.Queries.GetRoomsByBuildingId;
using Equipment.UseCases.Rooms.Commands.CreateRoom;
using Equipment.UseCases.Rooms.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equipment.UseCases.Buildings.Queries.GetBuildingEquipmentIndicatorStatus;
using Equipment.UseCases.EquipmentItems.Dto;
using Equipment.UseCases.Buildings.Queries.GetSummaryViewEquipmentItems;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator mediator;

        public BuildingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<BuildingDto>>> GetAsync()
        {
            var buildingDtos = await mediator.Send(new GetBuildingCollectionQuery());

            return Ok(buildingDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDto>> GetAsync(int id)
        {
            var buildingDto = await mediator.Send(new GetBuildingQuery { Id = id });

            return Ok(buildingDto);
        }

        [HttpGet("{id}/rooms")]
        public async Task<ActionResult<ICollection<RoomDto>>> GetRoomsAsync(int id)
        {
            var roomDtos = await mediator.Send(new GetRoomsByBuildingIdQuery { BuildingId = id });

            return Ok(roomDtos);
        }

        [HttpGet("{id}/equipmentItems")]
        public async Task<ActionResult<ICollection<SummaryViewEquipmentItemDto>>> GetEquipmentItemsAsync(int id)
        {
            var summaryViewEquipmentItemDtos = await mediator.Send(new GetSummaryViewEquipmentItemsQuery { BuildingId = id });

            return Ok(summaryViewEquipmentItemDtos);
        }

        [HttpGet("{id}/showEquipmentIndicator")]
        public async Task<ActionResult<bool>> ShowEquipmentIndicatorAsync(int id)
        {
            var isShowEquipmentIndicator = await mediator.Send(new GetBuildingEquipmentIndicatorStatusQuery { buildingId = id });

            return Ok(isShowEquipmentIndicator);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreateBuildingDto createBuildingDto)
        {
            var buildingId = await mediator.Send(new CreateBuildingCommand { Dto = createBuildingDto });

            return CreatedAtAction("Get", new { id = buildingId });
        }

        [HttpPost("{id}/room")]
        public async Task<ActionResult<int>> CreateRoomAsync(int id, [FromBody] CreateRoomDto createRoomDto)
        {
            var roomId = await mediator.Send(new CreateRoomCommand { BuildingId = id, Dto = createRoomDto });

            return CreatedAtAction("Get", "Room", new { id = roomId });
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] BuildingDto buildingDto)
        {
            await mediator.Send(new UpdateBuildingCommand { Dto = buildingDto });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await mediator.Send(new DeleteBuildingCommand { Id = id });

            return NoContent();
        }
    }
}
