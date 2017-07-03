using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Handlers.Jwt
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(string username, string role);
    }
}