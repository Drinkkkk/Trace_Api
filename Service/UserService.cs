using AutoMapper;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork Work;
        private readonly IMapper Mapper;

        public UserService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            Work = unitOfWork;
            this.Mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(UserDto entity)
        {
            try
            {
                var user=Mapper.Map<User>(entity);
                var repository = Work.GetRepository<User>();
                await repository.InsertAsync(user);
                if (await Work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, entity);
                else 
                    return new ApiResponse("数据增加失败");
            }
            catch (Exception ex)
            {

               return new ApiResponse(ex.Message);
            }
           
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = Work.GetRepository<User>();
                var user = await repository.GetFirstOrDefaultAsync(predicate: x => x.UserID.Equals(id));
                repository.Delete(user);
                if (await Work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "");
                }
                else
                    return new ApiResponse("删除数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var repository = Work.GetRepository<User>();
                
                var userlist = await repository.GetAllAsync();
                var userDtoList=Mapper.Map<List<UserDto>>(userlist);
                return new ApiResponse(true, userDtoList);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {

            try
            {
                var repository = Work.GetRepository<User>();
                var user = await repository.GetFirstOrDefaultAsync(predicate:x=>x.UserID.Equals(id));
                var userDto = Mapper.Map<UserDto>(user);
                return new ApiResponse(true, userDto);
               
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(UserDto entity)
        {
            try
            {
                var touser =Mapper.Map<User>(entity);
                var repository = Work.GetRepository<User>();
                var user = await repository.GetFirstOrDefaultAsync(predicate: x => x.UserID.Equals(touser.UserID));
                user.Username = touser.Username;
                user.Password = touser.Password;
                user.FullName = touser.FullName;
                user.Phone = touser.Phone;
                user.Role = touser.Role;
                user.UpdateDataTime=DateTime.Now;

                repository.Update(user);
                if (await Work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, entity);
                else
                    return new ApiResponse("更新数据异常");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
