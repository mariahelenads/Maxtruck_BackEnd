using Maxtruck.Application.Dtos;
using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Interfaces
{
    public interface IBridgeService
    {
        Task AddBridgeAsync(BridgeDto input);

        Task<List<BridgeDto>> GetBridgesAsync();

        Task<BridgeDto> GetBridgeByName(string name);
    }
}
