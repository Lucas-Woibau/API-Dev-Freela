using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserItemViewModel>>>
    {
        private readonly IUserRepository _repository;
        public GetAllUsersHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<UserItemViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll();

            var model = users.Select(UserItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(model);
        }
    }
}
