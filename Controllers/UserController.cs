using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Parameter;

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
        public async Task<ApiResponse> GetAll([FromBody] QueryParameter query) =>await Service.GetAllAsync(query);
        [HttpPost]
        public async Task<ApiResponse> Update([FromBody]UserDto user) => await Service.UpdateAsync(user);
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody]UserDto user) => await Service.AddAsync(user);
        [HttpDelete]
        public async Task<ApiResponse> Delete(int id ) => await Service.DeleteAsync(id);


        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto userDto) => await Service.LoginAsync(userDto);
        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] UserDto user) => await Service.ResgiterAsync(user);


        [HttpPost]
        public async Task<ApiResponse> GetFilterAsync([FromBody] FilterQuery query) => await Service.GetFilterAllAsync(query);
    }
}
