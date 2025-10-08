using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UserCommands.InsertUser
{
    public class ValidateInsertUserCommandBehavior : IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>
    {

        private DevFreelaDbContext _context;
        public ValidateInsertUserCommandBehavior(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userEmailExists = await _context.Users.AnyAsync(u => u.Email == request.Email);

            if (userEmailExists)
            {
                return ResultViewModel<int>.Error("Esse e-mail já está registrado!");
            }

            return await next();
        }
    }
}
