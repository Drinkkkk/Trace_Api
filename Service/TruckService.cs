using AutoMapper;
using System;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Service
{
    public class TruckService : ITruckServic
    {
        private readonly IUnitOfWork Work;
        private readonly IMapper Mapper;

        public TruckService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.Work = unitOfWork;
            this.Mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(TruckDto entity)
        {
            try
            {
                var truck = Mapper.Map<Truck>(entity);
                truck.CreateDataTime = DateTime.Now;
                truck.UpdateDataTime = DateTime.Now;
                var repository = Work.GetRepository<Truck>();
                await repository.InsertAsync(truck);
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
                var repository = Work.GetRepository<Truck>();
                var truck = await repository.GetFirstOrDefaultAsync(predicate: x => x.TruckID.Equals(id));
                repository.Delete(truck);
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
                
                var repository = Work.GetRepository<Truck>();

                var trucklist = await repository.GetAllAsync();
                var truckDtoList = Mapper.Map<List<UserDto>>(trucklist);
                return new ApiResponse(true, truckDtoList);
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
                var repository = Work.GetRepository<Truck>();
                var truck = await repository.GetFirstOrDefaultAsync(predicate: x => x.TruckID.Equals(id));
                var truckdto = Mapper.Map<TruckDto>(truck);
                return new ApiResponse(true, truckdto);

            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(TruckDto entity)
        {
            try
            {
                var totruck = Mapper.Map<Truck>(entity);
                var repository = Work.GetRepository<Truck>();
                var truck = await repository.GetFirstOrDefaultAsync(predicate: x => x.TruckID.Equals(totruck.TruckID));
                truck.Status =totruck.Status;
                truck.Manufacturer =totruck.Manufacturer;
                truck.LicensePlate =totruck.LicensePlate;
                truck.LoadCapacity =totruck.LoadCapacity;
                truck.VehicleModel=totruck.VehicleModel;
                truck.UpdateDataTime =DateTime.Now;
                repository.Update(truck);
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
