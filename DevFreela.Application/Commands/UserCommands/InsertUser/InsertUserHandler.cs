using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public InsertUserHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();

            var hashredPassword = _authService.ComputeHash(user.Password);

            user.SetPassword(hashredPassword);

            await _repository.Add(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
