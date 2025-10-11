using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GellAllSkills
{
    public class GetAllSkillsHanlder : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<SkillItemViewModel>>>
    {
        private readonly ISkillRepository _repository;
        public GetAllSkillsHanlder(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<SkillItemViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAll();

            var model = skills.Select(SkillItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<SkillItemViewModel>>.Success(model);
        }
    }
}
