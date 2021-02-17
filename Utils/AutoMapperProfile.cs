using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<GenreDTO, Genre>();
        }
    }
}
