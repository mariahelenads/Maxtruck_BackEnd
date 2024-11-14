using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
