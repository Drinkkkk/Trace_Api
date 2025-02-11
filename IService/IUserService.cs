

using Trace_Api.Dto;
using Trace_Api.Parameter;

namespace Trace_Api.IService
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<ApiResponse> LoginAsync(UserDto userDto);
        Task<ApiResponse> ResgiterAsync(UserDto userDto);
        Task<ApiResponse> GetFilterAllAsync(FilterQuery query);
    }
}
