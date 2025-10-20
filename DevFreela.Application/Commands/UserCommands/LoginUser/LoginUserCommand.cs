using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommand : IRequest<ResultViewModel<LoginViewModel>>
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
