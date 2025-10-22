using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginViewModel>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public LoginUserHandler(IUserRepository context, IAuthService authService)
        {
            _repository = context;
            _authService = authService;
        }
        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var hash = _authService.ComputeHash(request.Password);

            var user = await _repository.GetByEmail(request.Email);

            if (user is null || user.Password != hash)
            {
                return ResultViewModel<LoginViewModel?>.Error("Erro de login.");
            }

            var token = _authService.GenerateToken(user.Email, user.Role);

            var viewModel = new LoginViewModel(token);

            var result = ResultViewModel<LoginViewModel>.Success(viewModel);

            return result;
        }
    }
}
