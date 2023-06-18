using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;

namespace DataAccess.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookRequestDTO>().ReverseMap();
            CreateMap<BookRequestDTO, Book>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<BookDTO, BookRequestDTO>().ReverseMap();
            CreateMap<BookRequestDTO, BookDTO>().ReverseMap();
        }
    }
}
