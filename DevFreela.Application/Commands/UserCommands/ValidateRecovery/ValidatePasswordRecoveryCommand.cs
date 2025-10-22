using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.ValidatePasswordRecoveryCommand
{
    public class ValidatePasswordRecoveryCommand : IRequest<ResultViewModel>
    {
        public ValidatePasswordRecoveryCommand(string email, string code)
        {
            Email = email;
            Code = code;
        }

        public string Email { get; set; }
        public string Code { get; set; }
    }
}
