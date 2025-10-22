using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.RecoveryPassword
{
    public class PasswordRecoveryCommand : IRequest<ResultViewModel>
    {
        public PasswordRecoveryCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
