using CDE.Domain.Models;

namespace CDE.Domain.Interfaces.Jwt
{
    public interface IAuthenticationService
    {
        string GerarToken(JwtUsuarioModel jwtUsuarioModel);
    }
}
