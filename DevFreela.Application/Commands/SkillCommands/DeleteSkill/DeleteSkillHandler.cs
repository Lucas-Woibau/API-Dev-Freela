using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.DeleteSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, ResultViewModel>
    {
        private readonly ISkillRepository _repository;
        public DeleteSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetById(request.Id);

            if (skill == null)
            {
                return ResultViewModel.Error("Skill não existe!");
            }

            skill.SetAsDeleted();
            await _repository.Update(skill);

            return ResultViewModel.Success();
        }
    }
}
