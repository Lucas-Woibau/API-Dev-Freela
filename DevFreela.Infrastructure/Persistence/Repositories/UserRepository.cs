using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;

        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users
                .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users
                .Where(u => !u.IsDeleted)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<User?> GetDetailsById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .ThenInclude(us => us.Skill)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<User?> GetByEmail(string userEmail)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .ThenInclude(us => us.Skill)
                .FirstOrDefaultAsync(u => u.Email == userEmail);

            return user;
        }

        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Users
                .AnyAsync(p => p.Id == id);
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return;
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
