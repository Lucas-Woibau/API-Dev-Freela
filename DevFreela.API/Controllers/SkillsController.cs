using DevFreela.Application.Commands.SkillCommands.DeleteSkill;
using DevFreela.Application.Commands.SkillCommands.InsertSkill;
using DevFreela.Application.Commands.SkillCommands.UpdateSkill;
using DevFreela.Application.Queries.SkillQueries.GellAllSkills;
using DevFreela.Application.Queries.SkillQueries.GetSkillById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSkillByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteSkillCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
