using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trace_Api.IService;
using Trace_Api.Model;

namespace Trace_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService Service;

        public UserController(IUserService service)
        {
            Service = service;
           
        }

        [HttpGet]
       public async Task<ApiResponse> Get(int id) =>await Service.GetSingleAsync(id);

        [HttpPost]
        public async Task<ApiResponse> GetAll()=>await Service.GetAllAsync();
        [HttpPost]
        public async Task<ApiResponse> Updata([FromBody]User user) => await Service.UpdateAsync(user);
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody]User user) => await Service.AddAsync(user);
        [HttpDelete]
        public async Task<ApiResponse> Delete(int id ) => await Service.DeleteAsync(id);

    }
}
