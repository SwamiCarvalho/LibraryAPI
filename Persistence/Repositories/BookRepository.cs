﻿using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryAPI.Persistence.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {

        public  BookRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await AddAsync(book);
        }

        /*public IEnumerable<Book> GetAllBooks()
        {
            return FindAll()
                .OrderBy(b => b.Title);
        }

        public IEnumerable<Book> GetAllBooksWithDetails()
        {
            return FindAll()
                .Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)
                .OrderBy(b => b.Title).ToList();
        }

        public async Task<Book> GetBookByIdAsync(long id)
        {
            return await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookDetailsAsync(long? id)
        {
            return await FindByCondition(b => b.Id == id).AsQueryable()
                .Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)
                .OrderBy(b => b.Title).FirstOrDefaultAsync();

        }

        public bool BookExists(long id)
        {
            return FindAll().Any(b => b.Id == id);
        }*/

    }
}
