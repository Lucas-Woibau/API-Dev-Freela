using DevFreela.Application.Models;
using MediatR;

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
}
