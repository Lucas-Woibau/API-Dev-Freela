using DevFreela.Application.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.UserCommands.ValidatePasswordRecoveryCommand
{
    public class ValidatePasswordRecoveryHandler : IRequestHandler<ValidatePasswordRecoveryCommand, ResultViewModel>
    {
        private readonly IMemoryCache _cache;

        public ValidatePasswordRecoveryHandler(IMemoryCache cache)
        {
            _cache = cache;
        }

        Task<ResultViewModel> IRequestHandler<ValidatePasswordRecoveryCommand, ResultViewModel>.Handle(ValidatePasswordRecoveryCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"RecoveryCode: {request.Email}";

            if (!_cache.TryGetValue(cacheKey, out string? code) || code != request.Code)
            {
                return Task.FromResult(ResultViewModel.Error("Código invalido"));
            }

            return Task.FromResult(ResultViewModel.Success());
        }
    }
}
