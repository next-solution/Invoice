using System.Threading.Tasks;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string username);
        Task RegisterAsync(string username, string password, string fullname);
        Task LoginAsync(string username, string password);
    }
}