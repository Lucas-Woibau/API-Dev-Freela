using DevFreela.Application.Models;
using DevFreela.Infrastructure.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.UserCommands.RecoveryPassword
{
    public class PasswordRecoveryHandler : IRequestHandler<PasswordRecoveryCommand, ResultViewModel>
    {
        private readonly IMemoryCache _cache;
        private readonly IEmailService _emailService;

        public PasswordRecoveryHandler(IMemoryCache cache, IEmailService emailService)
        {
            _cache = cache;
            _emailService = emailService;
        }
        public async Task<ResultViewModel> Handle(PasswordRecoveryCommand request, CancellationToken cancellationToken)
        {
            var code = new Random().Next(100000, 999999).ToString();

            var cacheKey = $"RecoveryCode:{request.Email}";

            _cache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

            await _emailService.SendAsync(request.Email, "Código de Recuperação", $"Seu código de recuperação é {code}.");

            return ResultViewModel.Success();
        }
    }
}
