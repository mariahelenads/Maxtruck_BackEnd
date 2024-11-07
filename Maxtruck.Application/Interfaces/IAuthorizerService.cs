using Maxtruck.Domain.Models;

namespace Maxtruck.Application.Services
{
    public interface IAuthorizerService
    {
        string GenerateToken(string userId, string userName);
    }
}
