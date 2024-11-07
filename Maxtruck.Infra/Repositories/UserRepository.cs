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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetUserByEmailAsync] Error message: {ex.Message}");
                throw;
            }
        }
    }
}
