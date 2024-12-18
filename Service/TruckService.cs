using AutoMapper;
using System;
using System.Collections.ObjectModel;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Model;
using Trace_Api.Parameter;
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
                    return new ApiResponse(true, truck);
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

        public async Task<ApiResponse> GetAllAsync(QueryParameter query)
        {
            try
            {
                
                var repository = Work.GetRepository<Truck>();

                var trucklist = await repository.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(query.Search) ? true : x.Title.Contains(query.Search),
                    pageIndex: query.PageIndex, pageSize: query.PageSize,
                    orderBy: source => source.OrderBy(x => x.TruckID));
                var truckDtoList = Mapper.Map<PagedList<TruckDto>>(trucklist);
                return new ApiResponse(true, truckDtoList);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetFilterAsync(FilterQuery query)
        {

            try
            {

                var repository = Work.GetRepository<Truck>();

                var trucklist = await repository.GetPagedListAsync(predicate: x => (string.IsNullOrWhiteSpace(query.Search) ? true : x.Title.Contains(query.Search))&&(string.IsNullOrWhiteSpace(query.Filter)? true:x.Status.Equals(query.Filter)),
                    pageIndex: query.PageIndex, pageSize: query.PageSize,
                    orderBy: source => source.OrderBy(x => x.TruckID));
                var truckDtoList = Mapper.Map<PagedList<TruckDto>>(trucklist);
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
                truck.Title =totruck.Title;
                truck.Content =totruck.Content;
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
        public async Task<ApiResponse> GetSummaryAsync()
        {
            try
            {
                var trucks = await Work.GetRepository<Truck>().GetAllAsync(
                      orderBy: source => source.OrderByDescending(t => t.CreateDataTime));

                //行程结果
                var trips = await Work.GetRepository<Trip>().GetAllAsync(
                    orderBy: source => source.OrderByDescending(t => t.CreateDataTime));
                SummaryDto summary = new SummaryDto();
                summary.Sum = trucks.Count(); //汇总货车数量
                summary.CompletedCount = trucks.Where(t => t.Status == "true").Count(); //统计完成数量
                summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%"); //统计完成率
                summary.TripCount = trips.Count();  //汇总行程数量
                summary.TruckList = new ObservableCollection<TruckDto>(Mapper.Map<List<TruckDto>>(trucks.Where(t => t.Status == "false")));
                summary.TripList = new ObservableCollection<TripDto>(Mapper.Map<List<TripDto>>(trips));



                return new ApiResponse(true, summary);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
