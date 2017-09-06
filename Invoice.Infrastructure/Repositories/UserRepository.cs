﻿using Invoice.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Invoice.Core.Domain;
using System.Threading.Tasks;
using Invoice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, ISqlRepository
    {
        private readonly InvoiceContext _context;

        public UserRepository(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();

        public async Task<User> GetAsync(Guid id)
            => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string username)
            => await _context.Users.SingleOrDefaultAsync(x => x.Username == username);

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
       
        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
