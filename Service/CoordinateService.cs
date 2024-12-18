using AutoMapper;
using System;
using Trace_Api.Dto;
using Trace_Api.IService;
using Trace_Api.Model;
using Trace_Api.Parameter;
using Trace_Api.UnitOfWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Trace_Api.Service
{
    public class CoordinateService : ICoordinateService
    {
        private readonly IUnitOfWork Work;
        private readonly IMapper Mapper;

        public CoordinateService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.Work = unitOfWork;
            this.Mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(CoordinateDto entity)
        {
            try
            {
                var coordinate = Mapper.Map<Coordinate>(entity);
                var repository = Work.GetRepository<Coordinate>();
                await repository.InsertAsync(coordinate);
                if (await Work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, coordinate);
                return new ApiResponse("增加失败");
            }
            catch (Exception ex )
            {

                return new ApiResponse(ex.Message);
            }
          

        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = Work.GetRepository<Coordinate>();
                var coordinate = await repository.GetFirstOrDefaultAsync(predicate: x => x.CoordinateID.Equals(id));
                repository.Delete(coordinate);
                if (await Work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "");
                }
                else
                    return new ApiResponse("删除数据失败");
            }
            catch (Exception ex )
            {

                return new ApiResponse(ex.Message);
            }
           

        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter query)
        {
            try
            {
                var reposity = Work.GetRepository<Coordinate>();
                var coorlist = await reposity.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(query.Search) ? true : x.CoordinateID.Equals(query.Search),
                pageIndex: query.PageIndex, pageSize: query.PageSize,
                    orderBy: source => source.OrderBy(x => x.CoordinateID));
                var coortodo = Mapper.Map<PagedList<CoordinateDto>>(coorlist);
                return new ApiResponse(true, coortodo);
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
                var repository = Work.GetRepository<Coordinate>();
                var single = await repository.GetFirstOrDefaultAsync(predicate: x => x.CoordinateID.Equals(id));
                var coorDto = Mapper.Map<CoordinateDto>(single);
                return new ApiResponse(true, coorDto);
            }
            catch (Exception ex )
            {

                return new ApiResponse(ex.Message);
            }
          
        }

        public async Task<ApiResponse> UpdateAsync(CoordinateDto entity)
        {
            try
            {
                var toCoor = Mapper.Map<CoordinateDto>(entity);
                var repository = Work.GetRepository<Coordinate>();
                var Coor = await repository.GetFirstOrDefaultAsync(predicate: x => x.CoordinateID.Equals(toCoor.CoordinateID));

                Coor.Latitude = entity.Latitude;
                Coor.Longitude = entity.Longitude;
                Coor.UpdateDataTime = DateTime.Now;
                Coor.TripID = entity.TripID;
                Coor.Timestamp = entity.Timestamp;

                repository.Update(Coor);
                if (await Work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, entity);

                }
                else
                    return new ApiResponse("更新数据失败");
            }
            catch (Exception ex )
            {

                return  new ApiResponse(ex.Message);
            }
        

        }
    }
}
