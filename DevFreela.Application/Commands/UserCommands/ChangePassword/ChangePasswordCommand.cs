using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.UserCommands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ResultViewModel>
    {
        public ChangePasswordCommand(string email, string code, string newPassword)
        {
            Email = email;
            Code = code;
            NewPassword = newPassword;
        }

        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ResultViewModel>
    {
        private readonly IMemoryCache _cache;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public ChangePasswordHandler(IMemoryCache cache, IEmailService emailService, IUserRepository repository, IAuthService authService)
        {
            _cache = cache;
            _emailService = emailService;
            _repository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"RecoveryCode:{request.Email}";

            if (!_cache.TryGetValue(cacheKey, out string? code) || code != request.Code)
            {
                return ResultViewModel.Error("Código invalido");
            }

            _cache.Remove(cacheKey);

            var user = await _repository.GetByEmail(request.Email);

            if (user == null)
            {
                return ResultViewModel.Error("Usuário não encontrado.");
            }

            var hash = _authService.ComputeHash(request.NewPassword);

            user.UpdatePassword(hash);

            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }

}
