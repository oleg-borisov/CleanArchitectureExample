using Equipment.UseCases.EquipmentTypes.Commands.CreateEquipmentType;
using Equipment.UseCases.EquipmentTypes.Commands.DeleteEquipmentType;
using Equipment.UseCases.EquipmentTypes.Commands.UpdateEquipmentType;
using Equipment.UseCases.EquipmentTypes.Dto;
using Equipment.UseCases.EquipmentTypes.Queries.GetEquipmentType;
using Equipment.UseCases.EquipmentTypes.Queries.GetEquipmentTypeCollection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EquipmentTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<EquipmentTypeDto>>> GetAsync()
        {
            var equipmentTypeDtos = await mediator.Send(new GetEquipmentTypeCollectionQuery());

            return Ok(equipmentTypeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentTypeDto>> GetAsync(int id)
        {
            var equipmentTypeDto = await mediator.Send(new GetEquipmentTypeQuery { Id = id });

            return Ok(equipmentTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody]CreateEquipmentTypeDto createEquipmentTypeDto)
        {
            var equipmentTypeId = await mediator.Send(new CreateEquipmentTypeCommand { Dto = createEquipmentTypeDto });

            return CreatedAtAction("Get", new { id = equipmentTypeId });
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody]EquipmentTypeDto equipmentTypeDto)
        {
            await mediator.Send(new UpdateEquipmentTypeCommand { Dto = equipmentTypeDto });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await mediator.Send(new DeleteEquipmentTypeCommand { Id = id});

            return NoContent();
        }
    }
}
