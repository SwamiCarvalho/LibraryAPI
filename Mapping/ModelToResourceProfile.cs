using AutoMapper;
using LibraryAPI.Domain.Models;
using LibraryAPI.Resources;
using System.Linq;

namespace LibraryAPI.Utils
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Book, BookResource>()
                .ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.Genres.ToList()))
                .ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.Authors.ToList()));

            CreateMap<Book, BookDetailsResource>();
                //.ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.BooksGenres.Select(y => y.Genre).ToList()))
                //.ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.BooksAuthors.Select(y => y.Author).ToList()));

            CreateMap<Author, AuthorResource>();
            CreateMap<Genre, GenreResource>();
        }
    }
}
