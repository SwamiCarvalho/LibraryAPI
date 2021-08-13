﻿using System.Threading.Tasks;
using LibraryAPI.Persistence.Contexts;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}