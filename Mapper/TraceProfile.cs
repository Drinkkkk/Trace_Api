using AutoMapper;
using System.Security.Cryptography.Xml;
using Trace_Api.Dto;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Mapper
{
    public class TraceProfile : Profile
    {
        public TraceProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Truck, TruckDto>().ReverseMap();
            CreateMap<Trip, TripDto>().ReverseMap();
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
            CreateMap<PagedList<Truck>, PagedList<TruckDto>>().ReverseMap();
            CreateMap<PagedList<Trip>, PagedList<TripDto>>().ReverseMap();
            CreateMap<PagedList<Coordinate>, PagedList<CoordinateDto>>().ReverseMap();
            CreateMap<PagedList<User>, PagedList<UserDto>>().ReverseMap();


            CreateMap<List<Trip>, List<TripDto>>()
  .ConvertUsing(src => src.Select(trip => new TripDto
  {
      TripID = trip.TripID,
      TruckID = trip.TruckID,
      TripStartTime = trip.TripStartTime,
      TripEndTime = trip.TripEndTime,
      TripStatus = trip.TripStatus,
      ExpectedStartTime = trip.ExpectedStartTime,
      ExpectedEndTime = trip.ExpectedEndTime,
      Title = trip.Title,
      Content = trip.Content
  }).ToList());

            CreateMap<Truck, TruckAndCoordinateDto>()
           .ForMember(dto => dto.LatestCoordinate, opt => opt.MapFrom(tr => GetLatestCoordinate(tr)));




            CreateMap<PagedList<Truck>, PagedList<TruckAndCoordinateDto>>()
               .ForMember(dest => dest.Items, opt =>
               {
            opt.MapFrom(src => src.Items.Select(tr => new TruckAndCoordinateDto
            {
                // 假设 TruckAndCoordinateDto 中其他属性的映射保持不变，这里重点关注新增的坐标相关属性映射
                LatestCoordinate = GetLatestCoordinate(tr),
                // 这里如果 TruckAndCoordinateDto 还有其他来自 Truck 的属性需要映射，继续补充，比如
                // OtherProperty = tr.OtherPropertyFromTruck
                TruckID = tr.TruckID,
                LicensePlate = tr.LicensePlate,
                VehicleModel = tr.VehicleModel,
                Manufacturer = tr.Manufacturer,
                LoadCapacity = tr.LoadCapacity,
                Status = tr.Status,
                Title = tr.Title,
                Content = tr.Content,
            }).ToList());
         });

            CreateMap<Trip, TripDto>()
                   .ForMember(dest => dest.TripID, opt => opt.MapFrom(src => src.TripID))
                   .ForMember(dest => dest.TruckID, opt => opt.MapFrom(src => src.TruckID))
                   .ForMember(dest => dest.TripStartTime, opt => opt.MapFrom(src => src.TripStartTime))
                   .ForMember(dest => dest.TripEndTime, opt => opt.MapFrom(src => src.TripEndTime))
                   .ForMember(dest => dest.TripStatus, opt => opt.MapFrom(src => src.TripStatus))
                   .ForMember(dest => dest.ExpectedStartTime, opt => opt.MapFrom(src => src.ExpectedStartTime))
                   .ForMember(dest => dest.ExpectedEndTime, opt => opt.MapFrom(src => src.ExpectedEndTime))
                   .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                   .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                   // 处理坐标列表的映射
                   .ForMember(dest => dest.Coordinates, opt =>
                   {
                       opt.MapFrom(src => src.Coordinates != null ? src.Coordinates.Where(c => c.TripID == src.TripID).Select(c => new CoordinateDto
                       {
                           CoordinateID = c.CoordinateID,
                           TripID = c.TripID,
                           Longitude = c.Longitude,
                           Latitude = c.Latitude,
                           Timestamp = c.Timestamp
                       }).ToList() : new List<CoordinateDto>());
                   });


            CreateMap<PagedList<Trip>, PagedList<TripDto>>()
               .ForMember(dest => dest.Items, opt =>
               {
                   opt.MapFrom(src => src.Items.Select(trip => new TripDto
                   {
                       TripID = trip.TripID,
                       TruckID = trip.TruckID,
                       TripStartTime = trip.TripStartTime,
                       TripEndTime = trip.TripEndTime,
                       TripStatus = trip.TripStatus,
                       ExpectedStartTime = trip.ExpectedStartTime,
                       ExpectedEndTime = trip.ExpectedEndTime,
                       Title = trip.Title,
                       Content = trip.Content,
                       Coordinates = trip.Coordinates != null ? trip.Coordinates
                          .Where(c => c.TripID == trip.TripID)
                          .Select(c => new CoordinateDto
                          {
                              CoordinateID = c.CoordinateID,
                              TripID = c.TripID,
                              Longitude = c.Longitude,
                              Latitude = c.Latitude,
                              Timestamp = c.Timestamp
                          }).ToList() : new List<CoordinateDto>()
                   }).ToList());
               });

           
        }



        private static CoordinateDto? GetLatestCoordinate(Truck truck)
        {
            // 获取最新的坐标，如果没有坐标则返回null
            var latestCoordinate = truck.Trips?.SelectMany(t => t.Coordinates ?? new List<Coordinate>())
                         .OrderByDescending(c => c.Timestamp)
                         .FirstOrDefault();
            return latestCoordinate == null ? null : new CoordinateDto
            {
                CoordinateID = latestCoordinate.CoordinateID,
                TripID = latestCoordinate.TripID,
                Longitude = latestCoordinate.Longitude,
                Latitude = latestCoordinate.Latitude,
                Timestamp = latestCoordinate.Timestamp
            };


        }
    }
}
