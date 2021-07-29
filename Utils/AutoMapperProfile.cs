using AutoMapper;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Models.DTOs;
using System.Linq;

namespace LibraryAPI.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            //.ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.BooksGenres.Select(y => y.Genre).ToList()))
            //.ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.BooksAuthors.Select(y => y.Author).ToList()));

            CreateMap<Book, BookDetailsDTO>();
                //.ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.BooksGenres.Select(y => y.Genre).ToList()))
                //.ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.BooksAuthors.Select(y => y.Author).ToList()));

            CreateMap<Author, AuthorDTO>();
            CreateMap<Genre, GenreDTO>();
        }
    }
}
