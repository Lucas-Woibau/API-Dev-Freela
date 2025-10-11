using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.DeleteSkill
{
    public class DeleteSkillCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteSkillCommand(int id)
        {
            Id = id;
        }
    }
}
