using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRespository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;

        public SkillRespository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAll()
        {
            var skills = await _context.Skills
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return skills;
        }

        public async Task<Skill?> GetById(int id)
        {
            var skill = await _context.Skills
                .SingleOrDefaultAsync(u => u.Id == id);

            return skill;
        }

        public async Task<int> Add(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill.Id;
        }

        public async Task Update(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(u => u.Id == id);

            if (skill != null)
            {
                skill.SetAsDeleted();
                await _context.SaveChangesAsync();
            }
        }
    }
}
