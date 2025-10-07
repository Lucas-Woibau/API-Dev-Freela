
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public class UserSkillService : IUserSkillService
    {
        private readonly DevFreelaDbContext _context;
        public UserSkillService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<UserSkillItemViewModel>> GetSkillByUser(int id)
        {
            var usersSkills = _context.UserSkills
              .Where(us => us.IdUser == id)
              .Include(us => us.Skill)
              .ToList();

            var model = usersSkills
                .Select(UserSkillItemViewModel.FromEntity)
                .ToList();

            return ResultViewModel<List<UserSkillItemViewModel>>.Success(model);
        }

        public ResultViewModel<int> AddSkillToUser(int idUser, int idSkill)
        {
            var exists = _context.UserSkills.Any(us => us.IdUser == idUser && us.IdSkill == idSkill);
            if (exists)
                return ResultViewModel<int>.Error("Usuário já possui essa skill");

            var userSkill = new UserSkill(idUser, idSkill);

            _context.UserSkills.Add(userSkill);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(userSkill.Id);
        }

        public ResultViewModel RemoveSkillFromUser(int idUser, int idSkill)
        {
            var userSkill = _context.UserSkills.FirstOrDefault(us => us.IdUser == idUser && us.IdSkill == idSkill);
            if (userSkill == null)
                return ResultViewModel.Error("Skill não encontrada para o usuário");

            _context.UserSkills.Remove(userSkill);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
