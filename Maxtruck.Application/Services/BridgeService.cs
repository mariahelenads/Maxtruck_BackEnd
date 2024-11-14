using AutoMapper;
using Maxtruck.Application.Dtos;
using Maxtruck.Application.Exceptions;
using Maxtruck.Application.Interfaces;
using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Services
{
    public class BridgeService : IBridgeService
    {
        private readonly IBridgeRepository _bridgeRepository;
        private readonly IMapper _mapper;

        public BridgeService(IBridgeRepository bridgeRepository, IMapper mapper)
        {
            _bridgeRepository = bridgeRepository;
            _mapper = mapper;
        }
        public async Task AddBridgeAsync(BridgeDto bridge)
        {
            try
            {
                var input = _mapper.Map<Bridge>(bridge);

                await _bridgeRepository.AddAsync(input);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save bridge. Error message {ex.Message}");
            }
        }

        public async Task<BridgeDto> GetBridgeByName(string name)
        {
            try
            {
                var bridge = await _bridgeRepository.GetBridgeByNameAsync(name);

                if (bridge is null)
                {
                    throw new NotFoundException($"Bridge not found bridge with name:{name}");
                }

                return _mapper.Map<BridgeDto>(bridge);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get bridge with name {name}. Error message {ex.Message}");
            }
        }

        public async Task<List<BridgeDto>> GetBridgesAsync()
        {
            try
            {
                var bridges = await _bridgeRepository.GetAllAsync();
                return _mapper.Map<List<BridgeDto>>(bridges);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list bridges. Error message {ex.Message}");
            }
        }
    }
}
