namespace Trace_Api.IService
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync();
        Task<ApiResponse> GetSingleAsync(int id);
        Task<ApiResponse> AddAsync(T entity);
        Task<ApiResponse> UpdateAsync(T entity);
        Task<ApiResponse> DeleteAsync(int id);
    }
}
