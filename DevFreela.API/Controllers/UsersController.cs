using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id, UserSkillsInputModel model)
        {
            var userSkill = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();

            _service.UserSkills.AddRange(userSkill);
            _service.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";

            return Ok(description);
        }
    }
}
