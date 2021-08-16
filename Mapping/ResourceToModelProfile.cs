using AutoMapper;
using LibraryAPI.Domain.Models;
using LibraryAPI.Resources;

namespace LibraryAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveBookResource, Book>();
            CreateMap<SaveAuthorResource, Author>();
            CreateMap<SaveGenreResource, Genre>();
            CreateMap<AuthorResource, Author>();
            CreateMap<GenreResource, Genre>();

        }
    }
}
