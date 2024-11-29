using AutoMapper;
using Maxtruck.Application.Dtos;
using Maxtruck.Application.Exceptions;
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
        private readonly IBridgeRepository _bridgeRepository;
        private readonly IMapper _mapper;

        public TruckService(ITruckRepository truckRepository, IBridgeRepository bridgeRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _bridgeRepository = bridgeRepository;
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

        public async Task<List<Truck>> GetTrucksAsync()
        {
            try
            {
                var trucks = await _truckRepository.GetAllAsync();
                return trucks;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list trucks. Error message {ex.Message}");
            }
        }

        public async Task<List<Truck>> GetTrucksByUserIdAsync(Guid userId)
        {
            try
            {
                var trucks = await _truckRepository.GetTrucksByUserIdAsync(userId);

                if (trucks is null || !trucks.Any())
                {
                    throw new NotFoundException($"Could not find trucks for user id: {userId}");
                }

                return trucks;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list trucks by userId. Error message {ex.Message}");
            }
        }
        
        public async Task<TruckDetails> GetTruckDetailsAsync(Guid truckId)
        {
            try
            {
                var truck = await _truckRepository.GetByIdAsync(truckId);

                if (truck is null)
                {
                    throw new NotFoundException($"Could not find truck with id: {truckId}");
                }

                var truckDetails = _mapper.Map<TruckDetails>(truck);
                var heightInMeters = truck.Height / 100;
                var bridges = await _bridgeRepository.GetBridgeByMaxHeightAsync(heightInMeters);
                truckDetails.CriticalBridges = bridges;

                return truckDetails;              
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list bridges. Error message {ex.Message}");
            }
        }
    }
}
