using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;

namespace BusinessObject.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDTO>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.RoleDesc));
        }
    }
}
