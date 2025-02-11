using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Parameter;

namespace Trace_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckServic Service;

        public TruckController(ITruckServic Service)
        {
            this.Service = Service;
        }
        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await Service.GetSingleAsync(id);

        [HttpPost]
        public async Task<ApiResponse> GetAll([FromBody] QueryParameter query) => await Service.GetAllAsync(query);
        [HttpPost]
        public async Task<ApiResponse> GetFilter([FromBody] FilterQuery query) => await Service.GetFilterAsync(query);
        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] TruckDto entity) => await Service.UpdateAsync(entity);
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] TruckDto entity) => await Service.AddAsync(entity);
        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await Service.DeleteAsync(id);

        //汇总
        [HttpPost]
        public async Task<ApiResponse> Summary() => await Service.GetSummaryAsync();

        [HttpPost]
        public async Task<ApiResponse> GetCarAndCoor([FromBody] FilterQuery query) => await Service.GetCarAndCoordinateAsync(query);

    }
}
