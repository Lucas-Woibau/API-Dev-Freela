using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            if (user == null)
            {
                return ResultViewModel.Error("Usuário não existe!");
            }

            user.SetAsDeleted();
            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }
}
