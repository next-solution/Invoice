using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Domain;

namespace Invoice.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
         Task<User> GetAsync(Guid id);
         Task<User> GetAsync(string username);
         Task<IEnumerable<User>> GetAllAsync();
         Task AddAsync(User user);
         Task UpdateAsync(User user);
         Task RemoveAsync(Guid id);
         
    }
}