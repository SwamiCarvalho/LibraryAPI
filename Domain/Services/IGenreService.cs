﻿using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<GenreResponse> GetGenreByIdAsync(long id);
        Task<GenreResponse> SaveGenreAsync(Genre genre);
        Task<GenreResponse> UpdateGenreAsync(long id, Genre genre);
        Task<GenreResponse> DeleteGenreAsync(long id);
        //Task<BookResponse> GetGenreBooks(long id);
    }
}
