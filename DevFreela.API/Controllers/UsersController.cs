using DevFreela.Application.Models;
using DevFreela.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return NoContent();
        }
    }
}
