using CDE.Domain.ViewModels;

namespace CDE.Domain.Interfaces.Jwt
{
    public interface IAuthenticationService
    {
        string Token(UserJwtModel jwtUsuarioModel);
    }
}
