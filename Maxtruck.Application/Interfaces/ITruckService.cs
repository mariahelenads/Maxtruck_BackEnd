using Maxtruck.Application.Dtos;
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

        Task<List<TruckDto>> GetTrucksAsync();
    }
}
