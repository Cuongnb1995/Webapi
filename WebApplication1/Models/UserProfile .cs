using AutoMapper;
using WebApplication1.Models;

namespace webapi.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Employee, ViewEmployee>()
                .ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => $"{src.Department.DepartmentName}")
                )
                .ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(src => $"{src.Position.PositionName}")
                ).ReverseMap();
        }
    }
}
