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
    public class TruckRepository : Repository<Truck>, ITruckRepository
    {
        private readonly AppDbContext _context;

        public TruckRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Truck>?> GetTrucksByUserIdAsync(Guid userId)
        {
            try
            {
                return await _context.Trucks.Where(t => t.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetTrucksByUserIdAsync] Error message: {ex.Message}");
                throw;
            }
        }
    }
}
