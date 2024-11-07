using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Maxtruck.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllAsync] Error message: {ex.Message}");
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetByIdAsync] Error message: {ex.Message}");
                throw;
            }
        }
        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddAsync] Error message: {ex.Message}");
                throw;
            }
        }


        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateAsync] Error message: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity is not null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteAsync] Error message: {ex.Message}");
                throw;
            }
        }
    }
}
