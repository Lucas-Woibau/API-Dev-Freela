using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
