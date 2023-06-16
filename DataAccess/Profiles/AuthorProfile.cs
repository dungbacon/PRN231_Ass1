using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorRequestDTO>().ReverseMap();
            CreateMap< AuthorRequestDTO , Author>().ReverseMap();
        }
    }
}
