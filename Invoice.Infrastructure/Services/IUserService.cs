using System.Threading.Tasks;
using Invoice.Infrastructure.DTO;
using System.Collections.Generic;

namespace Invoice.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(string username);
        Task RegisterAsync(string username, string password, string fullname);
        Task LoginAsync(string username, string password);
    }
}