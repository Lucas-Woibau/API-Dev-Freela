using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;
        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<List<UserItemViewModel>> GetAll(string search = "")
        {
            var users = _context.Users
                .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
                .Where(u => !u.IsDeleted
                && (search == "" || u.FullName.Contains(search)))              
                .ToList();

            var model = users.Select(UserItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Skills)
                .ThenInclude(us => us.Skill)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuario não encontrado");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == model.IdUser);

            if (user == null)
            {
                return ResultViewModel.Error("Usuário não existe!");
            }

            user.Update(model.FullName, model.Email, model.BirthDate);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user == null)
            {
                return ResultViewModel.Error("Usuário não existe!");
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
