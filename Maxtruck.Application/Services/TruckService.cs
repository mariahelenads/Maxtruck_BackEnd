using AutoMapper;
using Maxtruck.Application.Dtos;
using Maxtruck.Application.Interfaces;
using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public TruckService(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task AddTruckAsync(TruckDto truck)
        {
            try
            {
                var input = _mapper.Map<Truck>(truck);
                input.CreatedAt = DateTime.Now;
                await _truckRepository.AddAsync(input);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save truck. Error message {ex.Message}");
            }
        }

        public async Task<List<TruckDto>> GetTrucksAsync()
        {
            try
            {
                var trucks = await _truckRepository.GetAllAsync();
                return _mapper.Map<List<TruckDto>>(trucks);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list bridges. Error message {ex.Message}");
            }
        }
    }
}
