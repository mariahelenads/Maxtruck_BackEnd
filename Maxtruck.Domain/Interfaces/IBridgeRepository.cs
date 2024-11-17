using Maxtruck.Domain.Models;

namespace Maxtruck.Domain.Interfaces
{
    public interface IBridgeRepository : IRepository<Bridge>
    {
        Task<Bridge?> GetBridgeByNameAsync(string bridgeName);

        Task<List<Bridge>?> GetBridgeByMaxHeightAsync(decimal maxHeight);
    }
}
