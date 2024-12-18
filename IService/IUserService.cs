

using Trace_Api.Dto;

namespace Trace_Api.IService
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<ApiResponse> LoginAsync(string username,string password);
        Task<ApiResponse> ResgiterAsync(UserDto userDto);
    }
}
