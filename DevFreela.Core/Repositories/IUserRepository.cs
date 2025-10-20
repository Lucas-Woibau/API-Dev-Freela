using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetDetailsById(int id);
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string userEmail);
        Task<int> Add(User user);
        Task Update(User user);
        Task<bool> Exists(int id);
        Task Delete(int id);
    }
}
