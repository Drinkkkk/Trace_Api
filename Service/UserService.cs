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
                return new ApiResponse(true, userlist);
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
               
                return new ApiResponse(true, user);
               
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

                var repository = Work.GetRepository<User>();
                var user = await repository.GetFirstOrDefaultAsync(predicate: x => x.UserID.Equals(entity.UserID));
                user.Username = entity.Username;
                user.Password = entity.Password;
                user.UpdateDataTime=DateTime.Now;
                repository.Update(user);
                if (await Work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, user);
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
