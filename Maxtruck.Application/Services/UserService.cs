using AutoMapper;
using Maxtruck.Application.Dtos;
using Maxtruck.Application.Exceptions;
using Maxtruck.Application.Interfaces;
using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;

namespace Maxtruck.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> ListAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return _mapper.Map<List<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to list users. Error message {ex.Message}");
            }
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(email);

                if (user is null)
                {
                    throw new NotFoundException($"User not found user with email:{email}");
                }

                return _mapper.Map<UserDto>(user);

            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get user with email {email}. Error message {ex.Message}");
            }
        }

        public async Task<bool> CreateUserAsync(UserDto user)
        {
            try
            {
                var input = _mapper.Map<User>(user);
                input.CreatedAt = DateTime.Now;
                input.Id = Guid.NewGuid();

                await _userRepository.AddAsync(input);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save user. Error message {ex.Message}");
            }
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {

            try
            {
                await _userRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user with id {id}. Error message {ex.Message}");
            }
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserDto user)
        {
            throw new NotImplementedException();

            //try
            //{


            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception($"Failed to update user with id {id}. Error message {ex.Message}");
            //}
        }
    }
}
