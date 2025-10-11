using DevFreela.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillsController : ControllerBase
    {
        private readonly IUserSkillService _service;

        public UserSkillsController(IUserSkillService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var result = _service.GetSkillByUser(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddSkillToUser(int idUser, int idSkill)
        {
            var result = _service.AddSkillToUser(idUser, idSkill);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSkill(int idUser, int idSkill)
        {
            var result = _service.RemoveSkillFromUser(idUser, idSkill);

            return NoContent();
        }
    }
}
