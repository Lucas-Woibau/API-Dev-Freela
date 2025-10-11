using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.UpdateSkill
{
    public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, ResultViewModel>
    {
        private readonly ISkillRepository _repository;
        public UpdateSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill =  await _repository.GetById(request.IdSkill);

            if (skill == null)
            {
                return ResultViewModel.Error("Skill não existe!");
            }

            skill.Update(request.Description);
            await _repository.Update(skill);

            return ResultViewModel.Success();
        }
    }
}
