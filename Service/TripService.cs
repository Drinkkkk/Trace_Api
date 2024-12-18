using AutoMapper;
using System;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Model;
using Trace_Api.Parameter;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Service
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork Work;
        private readonly IMapper Mapper;

        public TripService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.Work = unitOfWork;
            this.Mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(TripDto entity)
        {
            try
            {
                var trip = Mapper.Map<Trip>(entity);
                var repository = Work.GetRepository<Trip>();
                await repository.InsertAsync(trip);
                if (await Work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, trip);
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
                var repository = Work.GetRepository<Trip>();
                var trip = await repository.GetFirstOrDefaultAsync(predicate: x => x.TripID.Equals(id));
                repository.Delete(trip);
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
                var repository = Work.GetRepository<Trip>();

                var triplist = await repository.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(query.Search) ? true : x.TripID.Equals(query.Search),
                    pageIndex: query.PageIndex, pageSize: query.PageSize,
                    orderBy: source => source.OrderBy(x => x.TripStartTime));
                var TripDtoList = Mapper.Map<PagedList<TripDto>>(triplist);
                return new ApiResponse(true, TripDtoList);
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
                var repository = Work.GetRepository<Trip>();
                var trip = await repository.GetFirstOrDefaultAsync(predicate: x => x.TripID.Equals(id));
                var tripDto = Mapper.Map<TripDto>(trip);
                return new ApiResponse(true, tripDto);

            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(TripDto entity)
        {
            try
            {
                var totrip = Mapper.Map<Trip>(entity);
                var repository = Work.GetRepository<Trip>();
                var trip = await repository.GetFirstOrDefaultAsync(predicate: x => x.TripID.Equals(totrip.TripID));
               
              
                trip.Truck = totrip.Truck;
                trip.TripStartTime = totrip.TripStartTime;
                trip.TripEndTime = totrip.TripEndTime;
                trip.TripStatus = totrip.TripStatus;
                trip.UpdateDataTime = DateTime.Now;

                repository.Update(trip);
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
