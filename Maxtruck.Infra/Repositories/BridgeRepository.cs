using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Infra.Repositories
{
    public class BridgeRepository : Repository<Bridge>, IBridgeRepository
    {
        private readonly AppDbContext _context;

        public BridgeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Bridge?> GetBridgeByNameAsync(string bridgeName)
        {
            try
            {
                return await _context.Bridges.FirstOrDefaultAsync(u => u.Name == bridgeName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetBridgeByNameAsync] Error message: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Bridge>?> GetBridgeByMaxHeightAsync(decimal maxHeight)
        {
            try
            {
                Expression<Func<Bridge, bool>> filter = (bridge) =>              
                    (bridge.MaxHeightCentral != null && bridge.MaxHeightCentral < maxHeight) ||
                    (bridge.MaxHeightExpressway != null && bridge.MaxHeightExpressway < maxHeight) ||
                    (bridge.MaxHeightLocalRoad != null && bridge.MaxHeightLocalRoad < maxHeight) ||
                    (bridge.MaxHeightSingleRoad != null && bridge.MaxHeightSingleRoad < maxHeight);

                return await _context.Bridges.Where(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetBridgeByMaxHeight] Error message: {ex.Message}");
                throw;
            }
        }
    }
}
