using Maxtruck.Application.Dtos;
using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Interfaces
{
    public interface ITruckService
    {
        Task AddTruckAsync(TruckDto truck);

        Task<List<Truck>> GetTrucksAsync();

        Task<List<Truck>> GetTrucksByUserIdAsync(Guid userId);

        Task<TruckDetails> GetTruckDetailsAsync(Guid truckId);
    }
}
