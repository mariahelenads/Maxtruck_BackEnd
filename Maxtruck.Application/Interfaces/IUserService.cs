using Maxtruck.Application.Dtos;

namespace Maxtruck.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> ListAsync();

        Task<UserDto> GetUserByEmailAsync(string email);

        Task<bool> CreateUserAsync(UserDto user);

        Task<bool> UpdateUserAsync(Guid id, UserDto user);

        Task<bool> DeleteUserAsync(Guid id);

    }
}
