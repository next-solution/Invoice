using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;

namespace Invoice.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1", "NuTmrPTF76W4imQyOOHp2ygedZiclX1QbQv5vs9Z0N09u1oSrkT04g==",
                "YCWa1XoXNt72qLqpGpp3uN88X9a/ZGb/jfV3EFWM4HWZtfOA2guf7Q==", "Tomasz Kostecki"),
            new User("user2", "NuTmrPTF76W4imQyOOHp2ygedZiclX1QbQv5vs9Z0N09u1oSrkT04g==",
                "YCWa1XoXNt72qLqpGpp3uN88X9a/ZGb/jfV3EFWM4HWZtfOA2guf7Q==", "Mateusz Szczepański")
        };
        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        
        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id)); 

        public async Task<User> GetAsync(string username)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Username == username));

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}