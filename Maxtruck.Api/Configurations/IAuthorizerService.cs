using Maxtruck.Domain.Models;

namespace Maxtruck.Api.Configurations
{
    public interface IAuthorizerService
    {
        string GenerateToken(string userId, string userName);
    }
}
