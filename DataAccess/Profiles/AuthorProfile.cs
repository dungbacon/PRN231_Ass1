using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;

namespace DataAccess.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorRequestDTO>().ReverseMap();
            CreateMap<AuthorRequestDTO, Author>().ReverseMap();
            CreateMap<AuthorRequestDTO, AuthorDTO>().ReverseMap();
            CreateMap<AuthorDTO, AuthorRequestDTO>().ReverseMap();
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
