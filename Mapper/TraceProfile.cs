using AutoMapper;
using Trace_Api.Dto;
using Trace_Api.Model;

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
        }
    }
}
