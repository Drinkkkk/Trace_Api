using AutoMapper;
using Trace_Api.Dto;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Mapper
{
    public class TraceProfile:Profile
    {
        public TraceProfile()
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Truck, TruckDto>().ReverseMap();
            CreateMap<Trip, TripDto>().ReverseMap();
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
            CreateMap<PagedList<Truck>, PagedList<TruckDto>>().ReverseMap();
            CreateMap<PagedList<Trip>, PagedList<TripDto>>().ReverseMap();
            CreateMap<PagedList<Coordinate>, PagedList<CoordinateDto>>().ReverseMap();
         
        }
    }
}
