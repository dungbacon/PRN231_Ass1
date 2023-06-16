using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;

namespace DataAccess.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherRequestDTO>().ReverseMap();
            CreateMap<PublisherRequestDTO, Publisher>().ReverseMap();
        }
    }
}
