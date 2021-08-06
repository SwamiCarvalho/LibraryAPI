using AutoMapper;
using LibraryAPI.Domain.Models;
using LibraryAPI.Resources;
using System.Linq;

namespace LibraryAPI.Utils
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveBookResource, Book>();
            CreateMap<AuthorResource, Author>();
            CreateMap<GenreResource, Genre>();

        }
    }
}
