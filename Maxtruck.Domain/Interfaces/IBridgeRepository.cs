using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Domain.Interfaces
{
    public interface IBridgeRepository : IRepository<Bridge>
    {
        Task<Bridge?> GetBridgeByNameAsync(string bridgeName);
    }
}
