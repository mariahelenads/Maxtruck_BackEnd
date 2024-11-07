using Maxtruck.Domain.Models;

namespace Maxtruck.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetUserByEmailAsync(string email);
    }
}
