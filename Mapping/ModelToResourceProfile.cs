using AutoMapper;
using LibraryAPI.Domain.Models;
using LibraryAPI.Resources;
using System.Linq;

namespace LibraryAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Book, BookResource>()
                .ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.Genres.ToList()))
                .ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.Authors.ToList()));

            CreateMap<Book, BookDetailsResource>()
                .ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.Genres.ToList()))
                .ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.Authors.ToList()));

            CreateMap<Author, AuthorResource>();
            CreateMap<Genre, GenreResource>();
        }
    }
}
