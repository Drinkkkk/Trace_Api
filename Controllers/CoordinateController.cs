using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Parameter;

namespace Trace_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        private readonly ICoordinateService Service;

        public CoordinateController(ICoordinateService Service)
        {
            this.Service = Service;
        }
        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await Service.GetSingleAsync(id);

        [HttpPost]
        public async Task<ApiResponse> GetAll([FromBody] QueryParameter query) => await Service.GetAllAsync(query);
        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] CoordinateDto entity) => await Service.UpdateAsync(entity);
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] CoordinateDto entity) => await Service.AddAsync(entity);
        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await Service.DeleteAsync(id);
    }
}
