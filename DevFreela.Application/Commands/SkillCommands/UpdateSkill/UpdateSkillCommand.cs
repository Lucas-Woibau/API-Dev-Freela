using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.UpdateSkill
{
    public class UpdateSkillCommand : IRequest<ResultViewModel>
    {
        public int IdSkill { get; set; }
        public string Description { get; set; }
    }
}
