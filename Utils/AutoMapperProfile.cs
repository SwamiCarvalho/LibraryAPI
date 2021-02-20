using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTOs;

namespace LibraryAPI.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Genre,GenreDTO>();
        }
    }
}
