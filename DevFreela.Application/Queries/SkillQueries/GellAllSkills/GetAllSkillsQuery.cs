using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GellAllSkills
{
    public class GetAllSkillsQuery : IRequest<ResultViewModel<List<SkillItemViewModel>>>
    {
    }
}
