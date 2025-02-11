using Trace_Api.Dto;
using Trace_Api.Parameter;


namespace Trace_Api.IService
{
    public interface ITripService:IBaseService<TripDto>
    {
        Task<ApiResponse> GetFilterAsync(FilterQuery query);
    }
}
