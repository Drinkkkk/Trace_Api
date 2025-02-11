

using Trace_Api.Dto;
using Trace_Api.Parameter;

namespace Trace_Api.IService
{
    public interface ITruckServic : IBaseService<TruckDto>
    {
        Task<ApiResponse> GetFilterAsync(FilterQuery query);
        Task<ApiResponse> GetSummaryAsync();
        Task<ApiResponse> GetCarAndCoordinateAsync(FilterQuery query); 
    }
}
